using eHR.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<eHR.Service.ICodeService, eHR.Service.CodeService>();
builder.Services.AddScoped<eHR.Service.IEmployeeService, eHR.Service.EmployeeService>();

builder.Services.AddScoped<eHR.Dao.ICodeDao, eHR.Dao.CodeDao>();
builder.Services.AddScoped<eHR.Dao.IEmployeeDao, eHR.Dao.EmployeeDao>();
builder.Services.AddScoped<eHR.Dao.IDataAccessTool,eHR.Dao.DataAccessTool>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
