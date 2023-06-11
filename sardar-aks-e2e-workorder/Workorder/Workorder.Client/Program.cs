var builder = WebApplication.CreateBuilder(args);
var laborAPIUrl = builder.Configuration["LaborAPIUrl"];

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("LaborAPIUrl", client =>
{
    //client.BaseAddress = new Uri("http://host.docker.internal:5000/");
    //client.BaseAddress = new Uri("http://localhost:7001/api/Product");
    client.BaseAddress = new Uri(builder.Configuration["LaborAPIUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
