using BlazorServer.Providers;
using BlazorServer.Services;
using BlazorServer.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Authentication
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthClientService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<RoleHelper>();
builder.Services.AddSingleton<SystemFunctionsService>();

// HttpClient
builder.Services.AddScoped(sp =>
{
    var client = new HttpClient { BaseAddress = new Uri("http://localhost:5226/") };
    return client;
});

// Authorization
builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
