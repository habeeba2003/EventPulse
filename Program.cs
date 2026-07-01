using EventPulse.Components;
using EventPulse.Components.Account;
using EventPulse.Data;
using EventPulse.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── Database ─────────────────────────────────────────────────────────────────
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ── FIX 1: Register TimeProvider ─────────────────────────────────────────────
// .NET 8 Identity internally needs TimeProvider but doesn't register it
// automatically in some versions — we register it manually here
builder.Services.AddSingleton(TimeProvider.System);

// ── Identity (Authentication) ─────────────────────────────────────────────────
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// ── FIX 2: Register Authentication Schemes ────────────────────────────────────
// SignInManager needs IAuthenticationSchemeProvider which comes from
// AddAuthentication() — this was missing from the previous version
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

// ── FIX 3: Register Email Sender ──────────────────────────────────────────────
// Identity's Register/ForgotPassword pages require IEmailSender<ApplicationUser>
// to be registered, even if we don't send real emails yet. This no-op
// implementation satisfies that requirement so those pages don't crash.
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, NoOpEmailSender>();

// ── Blazor ────────────────────────────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider,
    IdentityRevalidatingAuthenticationStateProvider>();

// ── Build & Middleware Pipeline ───────────────────────────────────────────────
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();