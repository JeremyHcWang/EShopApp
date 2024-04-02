using Microsoft.EntityFrameworkCore;
using ProductAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using ProductAPI_Infrastructure.Data;
using ProductAPI_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddDbContext<EShopDbContext>(option =>
{
    // without env
    //option.UseSqlServer(builder.Configuration.GetConnectionString("EShopDbContextKey"));
    // with env
    option.UseSqlServer(Environment.GetEnvironmentVariable("EShopDbContextKey"));
});

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
