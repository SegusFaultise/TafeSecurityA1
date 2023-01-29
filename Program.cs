#region Imports
using SQL_WEB_APPLICATION.Context;
using SQL_WEB_APPLICATION.Models.Repository;
#endregion

#region Instanciate {builder} Variable From WebApplication Class

var builder = WebApplication.CreateBuilder(args);
#endregion

#region Add Services To The Container 

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(20);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion