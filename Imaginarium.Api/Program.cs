using Autofac;
using Imaginarium.Domain;
using Imaginarium.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ImaginariumDbContext>(opts =>
{
    opts
        .UseNpgsql(builder.Configuration.GetConnectionString("Database"),
        opts => opts.CommandTimeout(120))
        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.CommandError)); ;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Host.ConfigureContainer<ContainerBuilder>(RegisterModules);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterModules(HostBuilderContext hostBuilderContext, ContainerBuilder builder)
{
    builder.RegisterModule(new InfrastructureModule());
    builder.RegisterModule(new DomainModule());
}