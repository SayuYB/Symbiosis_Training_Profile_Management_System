using PlacementDemo.Data;
using Microsoft.EntityFrameworkCore;
using PlacementDemo.Services;


var builder = WebApplication.CreateBuilder(args);

//Register services here
builder.Services.AddControllersWithViews();

// Register LinkedInContext
builder.Services.AddDbContext<LinkedInContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your custom service
builder.Services.AddScoped<IProfileAnalysisService, ProfileAnalysisService>();

var app = builder.Build();


app.UseHttpsRedirection();
//for static files
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Configure the endpoints
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LinkedIn}/{action=ViewLinkedIn}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LinkedIn}/{action=AnalyzeProfile}/{id?}");

app.Run();
