using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    // builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    // app.Map("/error", (HttpContext httpContext) => {
    //     var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //     return Results.Problem(extensions: new Dictionary<string, object> {
    //         { "CustomProperty", "CustomValue" }
    //     });
    // });

    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}