using Microsoft.EntityFrameworkCore;
using Services = TeamManager.Application.Services;
using TeamManager.DataAccess.EF;
using TeamManager.DataAccess.Repositories;
using TeamManager.Domain.Repositories;

// Default ASP .NET MVC Builder
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// EF Core configuration
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<TeamManagerDbContext>(options =>
{
    // EF Core configured to PostgreSQL
    // Check if the version matchs
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("EldoradoTeamManager"),
        opts =>
        {
            // To check the version execute this query:
            // SELECT version();
            opts.SetPostgresVersion(new Version(15, 3));
        });
});

// Register Services
builder.Services.AddScoped<Services.Team.ITeamService, Services.Team.TeamService>();

// Register Repositories
builder.Services.AddScoped<ITeamRepository, TeamRepository>();

// Default ASP .NET Mvc App Setup
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
