using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenuCommand;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using BuberDinner.Domain.MenuAggregate;
using FluentAssertions;
using Moq;
using Xunit;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    // T1: SUT - what we're testing
    // T2: Scenario
    // T3: Expected outcome

    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidateCreateMenuCommands))]
    public async Task HandleCreateMenu_WhenMenuIsValid_ShouldCreatedAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        // Act
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.Add(It.Is<Menu>(menu => menu == result.Value)));
    }

    public static IEnumerable<object[]> ValidateCreateMenuCommands()
    {
        yield return new object[] { CreateMenuCommandUtils.CreateMenuCommand()};

        yield return new object[] { 
            CreateMenuCommandUtils.CreateMenuCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionCommands(sectionCount: 3)
            )
        };

        yield return new object[] { 
            CreateMenuCommandUtils.CreateMenuCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionCommands(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateMenuItemCommands(itemCount: 3)
                )
            )
        };
    }
}