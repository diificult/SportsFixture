using Microsoft.OpenApi.Models;
using SportsFixture.Data;
using SportsFixture.Dtos.Fixture;
using SportsFixture.Interfaces;
using SportsFixture.Repositorys;
using SportsFixture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SportsFixture.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SportsFixture.Interfaces.Subscription;
using SportsFixture.Services.Subscription;
using SportsFixture.Repositorys.Subscriptions;
using SportsFixture.Services.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Fixture Api", Version = "v1" });

    // Let Swagger know about polymorphism
    option.UseAllOfToExtendReferenceSchemas();

    // Register derived DTOs
    option.DocumentFilter<PolymorphismDocumentFilter<CreateFixtureDto>>();
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        ),
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


builder.Services.AddScoped(typeof(ISportFixtureBase<>), typeof(SportFixtureRepository<>));
builder.Services.AddScoped<MatchEventService>();
builder.Services.AddScoped<ISportCompetitionRepository, SportCompetitionRepository>();
builder.Services.AddScoped<ISportTeamRepository, SportsTeamRepository>();
builder.Services.AddScoped<ISportsRepository, SportsRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEventService<MatchEvent, UpdateMatchEventDto>, MatchEventService>();
builder.Services.AddScoped<IEventService<MultiTeamEvent, UpdateMultiTeamEventDto>, MultiTeamEventService>();

builder.Services.AddScoped<ISubscriptionRepository<TeamSubscription>, TeamSubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionRepository<FixtureSubscription>, FixtureSubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionRepository<CompetitionSubscription>, CompetitionSubscriptionRepository>();

builder.Services.AddScoped<ITeamSubscriptionService, TeamSubscriptionService>();
builder.Services.AddScoped<IFixtureSubscriptionService, FixtureSubscriptionService>();
builder.Services.AddScoped<ICompetitionSubscriptionService, CompeitionSubscriptionService>();
builder.Services.AddScoped<IapiSportService, apiFootballService>();
builder.Services.AddHttpClient<IapiSportService, apiFootballService>();
builder.Services.AddScoped<SportServiceFactory>();


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
