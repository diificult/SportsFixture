using Microsoft.OpenApi.Models;
using SportsFixture.Data;
using SportsFixture.Dtos.Fixture;
using SportsFixture.Interfaces;
using SportsFixture.Repositorys;
using SportsFixture.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Let Swagger know about polymorphism
    c.UseAllOfToExtendReferenceSchemas();

    // Register derived DTOs
    c.DocumentFilter<PolymorphismDocumentFilter<CreateFixtureDto>>();
});

builder.Services.AddScoped(typeof(ISportFixtureBase<>), typeof(SportFixtureRepository<>));
builder.Services.AddScoped<MatchEventService>();
builder.Services.AddScoped<ISportCompetitionRepository, SportCompetitionRepository>();
builder.Services.AddScoped<ISportTeamRepository, SportsTeamRepository>();
builder.Services.AddScoped<ISportsRepository, SportsRepository>();

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
