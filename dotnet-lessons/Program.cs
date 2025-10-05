using dotnet_lessons.Authorization;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);



// Add Razor Pages services
builder.Services.AddRazorPages();
builder.Services.AddAuthentication("MyCookieAuthentication").AddCookie("MyCookieAuthentication", options =>
{
    options.Cookie.Name = "MyCookieAuthentication";
    options.LoginPath = "/Account/login"; // Redirect to login page if not authenticated
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if access is denied
    options.ExpireTimeSpan = TimeSpan.FromSeconds(5); // Set cookie expiration time

});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("MustBelongToHrDepartment", policy => policy.RequireClaim("Department", "Hr"));
    options.AddPolicy("HRManagerOnly", policy => policy
    .RequireClaim("Department", "Hr")
    .RequireClaim("Manager")
    .Requirements.Add(new HrManagementProbationRequirement(3))
    );

});
builder.Services.AddSingleton<IAuthorizationHandler, HrManagementProbationRequirementHandler>();



var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles(); // Serves wwwroot static content (optional)

app.UseRouting(); // Enables routing

app.UseAuthentication(); // Enables authentication
app.UseAuthorization(); // Enables authorization

// Map Razor Pages
app.MapRazorPages();

app.Run();
