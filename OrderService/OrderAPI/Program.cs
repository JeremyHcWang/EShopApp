using Microsoft.EntityFrameworkCore;
using OrderAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using OrderAPI_Infrastructure.Data;
using OrderAPI_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<EShopDbContext>(option =>
{
    // if (!string.IsNullOrEmpty(builder.Configuration.GetConnectionString("EShopDbContextKey")))
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
