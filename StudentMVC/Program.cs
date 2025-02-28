var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient();


var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Students}/{action=Index}/{id?}"); });
app.Run();
