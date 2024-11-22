using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Test.TestBase;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;

public abstract class TestsBaseFixture : UnitTestsBase
{
    protected IEventPublisher MessageBus;
    protected IRequestDispatcher InMemoryBus;
    protected IOwnerAggregateRepository OwnerAggregateRepository;
    protected IOwnerValidatorService OwnerValidatorService;
    protected List<Owner> Owners;

    ///// <summary>
    /////
    ///// </summary>
    protected override void FixtureSetup()
    {
        CommonFixtureSetup();

        TestClassFixtureSetup();
    }

    /// <summary>
    ///
    /// </summary>
    private void CommonFixtureSetup()
    {
        MessageBus = Substitute.For<IEventPublisher>();

        InMemoryBus = Substitute.For<IRequestDispatcher>();

        Owners = GenerateOwnerList();

        OwnerValidatorService = Substitute.For<IOwnerValidatorService>();

        OwnerValidatorService
            .OwnerHasUniqueEmail(ownerId: Arg.Any<string>(), email: Arg.Any<string>())
            .Returns(args =>
            {
                return !Owners.Any(o => o.Id != (string)args[0] && o.Email.Value == (string)args[1]);
            });

        OwnerAggregateRepository = Substitute.For<IOwnerAggregateRepository>();
        OwnerAggregateRepository
            .GetByIdAsync(Arg.Is<string>(x => Owners.Any(o => o.Id == x)))
            .Returns(args => Owners.First(u => u.Id == (string)args[0]));
        OwnerAggregateRepository
            .AddAsync(Arg.Any<Owner>())
            .Returns(args =>
            {
                Owners.Add((Owner)args[0]);
                return Task.CompletedTask;
            });
        OwnerAggregateRepository
            .UpdateAsync(Arg.Is<Owner>(x => Owners.Any(o => o.Id == x.Id)))
            .Returns(args =>
            {
                var existOwner = Owners.FirstOrDefault(u => u.Id == ((Owner)args[0]).Id);
                if (existOwner != null)
                {
                    Owners.Remove(existOwner);
                    Owners.Add((Owner)args[0]);
                }

                return Task.CompletedTask;
            });
        OwnerAggregateRepository
            .GetByOrganizationIdAsync(Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                return Owners.FirstOrDefault(u => u.Organizations.Any(c => c.Id == (string)args[0]));
            });
        OwnerAggregateRepository
            .GetByProjectIdAsync(Arg.Is<string>(x => x.Any()))
            .Returns(args =>
            {
                return Owners.FirstOrDefault(u => u.Organizations.Any(c => c.Projects.Any(p => p.Id == (string)args[0])));
            });
    }

    /// <summary>
    /// Each test class should setup its own fixture
    /// </summary>
    protected abstract void TestClassFixtureSetup();

    /// <summary>
    ///
    /// </summary>
    private List<Owner> GenerateOwnerList()
    {
        var ownerValidatorService = Substitute.For<IOwnerValidatorService>();
        ownerValidatorService.OwnerHasUniqueEmail(ownerId: Arg.Any<string>(), email: Arg.Any<string>()).Returns(true);
        return OwnerObjectMother.GenerateOwnersList(ownerValidatorService);
    }
}
