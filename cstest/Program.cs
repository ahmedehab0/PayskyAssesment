using cstest.Services;
using cstest.Models;
using cstest.Repositeries;
using cstest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext with PostgreSQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


// Register services with appropriate lifetimes
builder.Services.AddScoped<IAccountHolderService, AccountHolderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();

// Register account services and factory for dynamic resolution
builder.Services.AddScoped<SavingsAccountService>();
builder.Services.AddScoped<CheckingAccountService>();
builder.Services.AddScoped<Func<string, IAccountOperation>>(provider => key =>
{
    return key switch
    {
        "checking" => provider.GetService<CheckingAccountService>(),
        "saving" => provider.GetService<SavingsAccountService>(),
        _ => throw new ArgumentException("Invalid service key")
    };
});

// Add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Serve static files (make sure you have a 'wwwroot' folder for static files)
app.UseStaticFiles();

app.UseAuthorization();

// Configure the default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
