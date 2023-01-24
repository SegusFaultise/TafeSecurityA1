#region Imports
using SQL_WEB_APPLICATION;
using SQL_WEB_APPLICATION.Controllers;
using SQL_WEB_APPLICATION.Models;
using Microsoft.AspNetCore.Mvc;
#endregion

#region Instanciate {builder} Variable From WebApplication Class

var builder = WebApplication.CreateBuilder(args);
#endregion

#region Add Services To The Container 

//builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
//builder.Services.AddSingleton<MongoDBServices>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
#endregion

#region Instanciate {app} Variable With Build() From {builder} variable

var app = builder.Build();
#endregion

#region Configure The HTTP Request Pipeline & Control When Swagger Is In Use

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion