using CqrsMediatrExample;
using CqrsMediatrExample.Behaviours;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(typeof(Program));
// Registers MediatR and its related services to the dependency injection container.
// Uses the typeof(Program) as the marker type to scan for MediatR handlers and related types.

builder.Services.AddSingleton<FakeDataStore>();
// Adds a singleton service of type FakeDataStore to the dependency injection container.
// Singletons are instantiated once and shared throughout the application.

builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
// Adds a singleton service for the IPipelineBehavior interface.
// Registers the LoggingBehaviour class as the implementation for all pipeline behaviors.

builder.Services.AddControllers();
// Adds controllers to the dependency injection container.
// Allows the controllers to be used in the application.

var app = builder.Build();
// Builds the WebApplication instance.

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
// Redirects HTTP requests to HTTPS.

app.UseAuthorization();
// Enables authorization for the application.

app.MapControllers();
// Maps the controllers in the application.

app.Run();
// Runs the application.
