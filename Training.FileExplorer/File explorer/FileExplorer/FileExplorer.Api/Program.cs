using FileExplorer.Api.Configurations;
using FileExplorer.Application.FileStorage.Broker;
using FileExplorer.Infrastructure.FileStorage.Brokers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();