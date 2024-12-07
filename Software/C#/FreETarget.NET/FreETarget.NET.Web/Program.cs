using FreETarget.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
    .UseSqlite("Data Source=..\\FreETargetNet.db")
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOpenApi();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.Run();
