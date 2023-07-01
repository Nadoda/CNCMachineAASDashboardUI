
using BaSyx.AAS.Client.Http;
using CNCMachineAASDashboard.Server.Backgroundservice;
using CNCMachineAASDashboard.Server.SignalRHub;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHostedService<BackgroundProcess>();

builder.Services.AddHttpClient();
builder.Services.AddSignalR();
//builder.Services.AddSingleton<AAShub>();
//builder.Services.AddSingleton<MaintenanceSMhub>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapHub<AAShub>("/dataSend");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<ConnectionAPI>("/Connection");

//});
app.MapFallbackToFile("index.html");

app.Run();
