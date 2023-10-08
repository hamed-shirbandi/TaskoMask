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

    Target Information => _ => _
        .Executes(() =>
        {
            Log.Information($"Solution path : {Solution}");
            Log.Information($"Solution directory : {Solution.Directory}");
            Log.Information($"Configuration : {Configuration}");
            Log.Information($"TestResultDirectory : {TestResultDirectory}");
        });

    Target Preparation => _ => _
        .DependsOn(Information)
        .Executes(() =>
        {
            TestResultDirectory.CreateOrCleanDirectory();
        });

    Target RestoreDotNetTool => _ => _
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

    Target RunUnitTests => _ => _
        .DependsOn(Compile)
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
        .DependsOn(RunUnitTests,RestoreDotNetTool)
        .Executes(() =>
        {
            ////It uses dashboard report for CI
            //string report = "--reporter dashboard";

            ////It uses reports specified in reports section in stryker-config.json
            //if (IsLocalBuild)
            //    report = "";

            var testProjects = Solution.AllProjects.Where(s => s.Name.EndsWith(".Tests.Unit"));

            foreach (var testProject in testProjects)
                DotNet(workingDirectory: testProject.Directory, arguments: $"dotnet-stryker");
        });
}
