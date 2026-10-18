using CleanArchitecture.API;
using CleanArchitecture.API.Exceptions;
using CleanArchitecture.Application;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services
    .AddApplicationModule()
    .AddDomainModule()
    .AddInfrastructureModule(configuration);

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<AppExceptionHandler>();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.Run();
