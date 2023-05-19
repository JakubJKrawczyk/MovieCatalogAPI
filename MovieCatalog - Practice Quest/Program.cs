using Microsoft.EntityFrameworkCore;
using MovieCatalog___Practice_Quest.Database;
using MovieCatalog___Practice_Quest.Interfaces;
using MovieCatalog___Practice_Quest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MovieCatalogDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHttpLogging();

app.MapControllers();

app.Run();
