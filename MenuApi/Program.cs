using FluentValidation;
using FluentValidation.AspNetCore;
using MenuApi.Application.Commands.CreateMenu;
using MenuApi.Application.Validators;
using MenuApi.Filters;
using MenuApi.Infrastructure.Persistence;
using MenuApi.Infrastructure.Persistence.Repositories;
using MenuApi.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<CreateMenuCommand>());
builder.Services.AddControllers(option => option.Filters.Add(typeof(ValidationFilter)));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(CreateCategoryCommandValidator).Assembly);
builder.Services.AddDbContext<MenuDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MenuAPI",
        Description = "Web API for menu and product registration."
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
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
