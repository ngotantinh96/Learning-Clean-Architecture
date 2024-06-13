using BuberDinner.Application.Menus.Commands.CreateMenuCommand;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateMenuCommand(
        List<CreateMenuSectionCommand>? sections = null) =>
        new (
            Constants.Host.Id.Value,
            Constants.Menu.Name,
            Constants.Menu.Description,
            sections ?? CreateMenuSectionCommands()
        );

    public static List<CreateMenuSectionCommand> CreateMenuSectionCommands(
        int sectionCount = 1,
        List<CreateMenuItemCommand>? items = null) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index), 
                    Constants.Menu.SectionDescriptionFromIndex(index),
                    items ?? CreateMenuItemCommands()
            ))
            .ToList();

    public static List<CreateMenuItemCommand> CreateMenuItemCommands(int itemCount = 1) =>
        Enumerable.Range(0, itemCount)
            .Select(index => new CreateMenuItemCommand(
                    Constants.Menu.ItemNameFromIndex(index), 
                    Constants.Menu.ItemDescriptionFromIndex(index)
            ))
            .ToList();
}