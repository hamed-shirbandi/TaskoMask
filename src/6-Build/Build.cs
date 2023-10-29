using Serilog;
using System.Linq;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Coverlet;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.NuGet;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Common.Tools.NuGet.NuGetPackSettingsExtensions;
using Nuke.Common.IO;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.RunMutationTests);

    [Parameter]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution]
    readonly Solution Solution;

    [Parameter]
    AbsolutePath TestResultDirectory = RootDirectory + "/.nuke/Artifacts/Test-Results/";

    Target LogInformation => _ => _
        .Executes(() =>
        {
            Log.Information($"Solution path : {Solution}");
            Log.Information($"Solution directory : {Solution.Directory}");
            Log.Information($"Configuration : {Configuration}");
            Log.Information($"TestResultDirectory : {TestResultDirectory}");
        });

    Target Preparation => _ => _
        .DependsOn(LogInformation)
        .Executes(() =>
        {
            TestResultDirectory.CreateOrCleanDirectory();
        });

    Target RestoreDotNetTools => _ => _
        .Executes(() =>
        {
            DotNet(arguments: "tool restore");
        });

    Target Clean => _ => _
        .DependsOn(Preparation)
        .Executes(() =>
        {
            DotNetClean();
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetRestore(a => a.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(a =>
                a.SetProjectFile(Solution)
                    .SetNoRestore(true)
                    .SetConfiguration(Configuration));
        });

    Target Lint => _ => _
    .DependsOn(Compile)
    .Executes(() =>
    {
        DotNet("csharpier .");
        DotNet("format style --verbosity diagnostic");
        DotNet("format analyzers --verbosity diagnostic");
    });

    Target LintCheck => _ => _
.DependsOn(Compile)
.Executes(() =>
{
    DotNet("csharpier --check .");
    DotNet("format style --verify-no-changes --verbosity diagnostic");
    DotNet("format analyzers --verify-no-changes --verbosity diagnostic");
});

    Target RunUnitTests => _ => _
        .DependsOn(LintCheck)
        .Executes(() =>
        {
            var testProjects = Solution.AllProjects.Where(s => s.Name.EndsWith("Tests.Unit"));

            DotNetTest(a => a
                .SetConfiguration(Configuration)
                .SetNoBuild(true)
                .SetNoRestore(true)
                .ResetVerbosity()
                .SetResultsDirectory(TestResultDirectory)
                    .EnableCollectCoverage()
                    .SetCoverletOutputFormat(CoverletOutputFormat.opencover)
                    .SetExcludeByFile("*.Generated.cs")
                    .EnableUseSourceLink()
                .CombineWith(testProjects, (b, z) => b
                    .SetProjectFile(z)
                    .AddLoggers($"trx;LogFileName={z.Name}.trx")
                    .SetCoverletOutput(TestResultDirectory + $"{z.Name}.xml")));
        });

    Target RunMutationTests => _ => _
        .DependsOn(RunUnitTests,RestoreDotNetTools)
        .Executes(() =>
        {
            //It will add dashboard reporter for CI
            string reporter = "--reporter dashboard";

            //It just uses the reporters specified in reporters section in stryker-config.json
            if (IsLocalBuild)
                reporter = "";

            var testProjects = Solution.AllProjects.Where(s => s.Name.EndsWith(".Tests.Unit"));

            foreach (var testProject in testProjects)
                DotNet(workingDirectory: testProject.Directory, arguments: $"stryker {reporter}");
        });
}
