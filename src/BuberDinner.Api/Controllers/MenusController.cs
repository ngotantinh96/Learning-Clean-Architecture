using BuberDinner.Application.Menus.Commands.CreateMenuCommand;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("host/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await mediator.Send(command);

        return createMenuResult.Match(
            menu => Ok(mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );
    }
}