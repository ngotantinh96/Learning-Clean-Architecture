using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenuCommand;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            hostId: HostId.Create(request.HostId),
            request.Name,
            request.Description,
            sections: request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                items: section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            ))
        );

        menuRepository.Add(menu);

        return menu;
    }
}
