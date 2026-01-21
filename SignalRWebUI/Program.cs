using SignalRWebUI.Extensions;
using SignalRWebUI.Helpers.Dropdown;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI", policy =>
    {
        policy.WithOrigins(
            "https://localhost:7249",  // WebUI HTTPS
            "http://localhost:5176"    // WebUI HTTP
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddScoped<IDropdownHelper, DropdownHelper>();

builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCors("AllowWebUI");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
