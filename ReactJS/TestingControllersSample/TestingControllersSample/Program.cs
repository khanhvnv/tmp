using Microsoft.EntityFrameworkCore;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
                optionsBuilder => optionsBuilder.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBrainstormSessionRepository, EFStormSessionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    using (ServiceProvider serviceProvider = builder.Services.BuildServiceProvider())
    {
        var repository = serviceProvider.GetRequiredService<IBrainstormSessionRepository>();

        InitializeDatabaseAsync(repository).Wait();
    }
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

async Task InitializeDatabaseAsync(IBrainstormSessionRepository repo)
{
    var sessionList = await repo.ListAsync();
    if (!sessionList.Any())
    {
        await repo.AddAsync(GetTestSession());
    }
}

static BrainstormSession GetTestSession()
{
    var session = new BrainstormSession()
    {
        Name = "Test Session 1",
        DateCreated = new DateTime(2016, 8, 1)
    };
    var idea = new Idea()
    {
        DateCreated = new DateTime(2016, 8, 1),
        Description = "Totally awesome idea",
        Name = "Awesome idea"
    };
    session.AddIdea(idea);
    return session;
}