using ApiPrueba.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors();



builder.Services.AddDbContext<ClienteDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiData"));

});

builder.Services.AddDbContext<ServicioDbContextcs>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiData"));

});

builder.Services.AddDbContext<FacturaDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiData"));

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
