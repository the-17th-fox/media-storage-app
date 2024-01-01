using Shared.Extensions;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDependencies(configuration);
services.AddHttpContextAccessor();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var corsPolicyName = configuration
    .GetSection($"CorsConfiguration:PolicyName")
    .Get<string>();

if (!corsPolicyName.IsNullOrWhiteSpace())
    app.UseCors(corsPolicyName);

app.Run();
