var builder = WebApplication.CreateBuilder(args);



// Add Razor Pages services
builder.Services.AddRazorPages();
builder.Services.AddAuthentication("MyCookieAuthentication").AddCookie("MyCookieAuthentication", options =>
{
    options.Cookie.Name = "MyCookieAuthentication";
    options.LoginPath = "/Account/Login"; // Redirect to login page if not authenticated
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if access is denied

});

// Add OpenAPI/Swagger if needed
builder.Services.AddOpenApi();

var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
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
