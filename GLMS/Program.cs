using Microsoft.EntityFrameworkCore;
using GLMS.Data;        // Make sure your namespace matches your project
using GLMS.Services;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// ?? SERVICES CONFIGURATION
// ========================================

// Add MVC services
builder.Services.AddControllersWithViews();

// Add DbContext (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add HttpClient for Currency API (Async/Await requirement)
builder.Services.AddHttpClient<CurrencyService>();

// Register Strategy Pattern
builder.Services.AddScoped<IPricingStrategy, CurrencyPricingStrategy>();

// ========================================
// ?? BUILD APP
// ========================================

var app = builder.Build();

// ========================================
// ?? DATABASE SEEDING (IMPORTANT)
// ========================================

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInitializer.Seed(context);
}

// ========================================
// ?? MIDDLEWARE PIPELINE
// ========================================

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS + Static Files (needed for PDF access)
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}"
);

// ========================================
// ?? RUN APP
// ========================================

app.Run();