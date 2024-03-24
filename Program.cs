using FluentValidation;
using Hafta10.Web.Extensions;
using Hafta10.Web.Data;
using FluentValidation.AspNetCore;
using Hafta10.Web.Models.Validators;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<KullaniciValidator>());



var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = "/wwwroot"
});

app.mainEx(); // middleware çalýþtýðýnda kullanýcýnýn ne zaman girip çýktýðýný dosyaya kaydeder.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Anasayfa");
    app.UseHsts();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

//app.UseMiddleware<mainMiddlewares>();
//app.MapControllerRoute(
//    name: "Kullanici",
//    "kullanici/{action = Kayit}", new { controller = "kullanici"});
app.MapControllerRoute("Anasayfa","{controller=AnaSayfa}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
