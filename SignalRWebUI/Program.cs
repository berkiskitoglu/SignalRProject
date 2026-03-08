using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Extensions;
using SignalRWebUI.Helpers.Dropdown;

var builder = WebApplication.CreateBuilder(args);
var requireAuthorizedPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddDbContext<SignalRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<SignalRContext>();
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddScoped<IDropdownHelper, DropdownHelper>();
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizedPolicy));
})
.AddDataAnnotationsLocalization()
.ConfigureApiBehaviorOptions(options => { })
.AddMvcOptions(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Bu alan zorunludur.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => $"'{x}' geçerli bir değer değildir.");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => $"'{x}' geçerli bir değer değildir.");
    options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => $"'{x}' alanı zorunludur.");
});
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});
builder.Services.AddSignalR();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();