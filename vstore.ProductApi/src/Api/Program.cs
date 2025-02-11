using Microsoft.EntityFrameworkCore;
using vstore.ProductApi.Api.Mapping;
using vstore.ProductApi.Core.Domain.Interfaces.Repositories;
using vstore.ProductApi.Core.Domain.Interfaces.Services;
using vstore.ProductApi.Core.Services;
using vstore.ProductApi.CrossCutting.IoC;
using vstore.ProductApi.CrossCutting.Utils.Extensions;
using vstore.ProductApi.Infrastructure.Context;
using vstore.ProductApi.Infrastructure.Middleware;
using vstore.ProductApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddApplicationServices(configuration);

var app = builder.Build();

app.UseSwaggerSetup();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();