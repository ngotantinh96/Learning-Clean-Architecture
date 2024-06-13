using BuberDinner.Application.Menus.Commands.CreateMenuCommand;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using FluentAssertions;

namespace BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;

public static partial class MenuExtensions
{
    public static void ValidateCreatedFrom(this Menu menu, CreateMenuCommand command)
    {
        menu.Name.Should().Be(command.Name);
        menu.Description.Should().Be(command.Description);

        menu.Sections.Should().HaveSameCount(command.Sections);
        menu.Sections.Zip(command.Sections).ToList()
            .ForEach(pair => ValidateSection(section: pair.First, command: pair.Second));
    }

    private static void ValidateSection(MenuSection section, CreateMenuSectionCommand command)
    {
        section.Id.Should().NotBeNull();
        section.Name.Should().Be(command.Name);
        section.Description.Should().Be(command.Description);

        section.Items.Should().HaveSameCount(command.Items);
        section.Items.Zip(command.Items).ToList()
            .ForEach(pair => ValidateItem(item: pair.First, command: pair.Second));
    }

    private static void ValidateItem(MenuItem item, CreateMenuItemCommand command)
    {
        item.Id.Should().NotBeNull();
        item.Name.Should().Be(command.Name);
        item.Description.Should().Be(command.Description);
    }
}