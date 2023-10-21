using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSyncfusionBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

var SyncfusionLicenseKey = builder.Configuration["Syncfusion:LicenseKey"];
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncfusionLicenseKey);

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
