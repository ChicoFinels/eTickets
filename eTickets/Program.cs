using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuração do DbContext
var dbpath = Path.Combine(Directory.GetCurrentDirectory(), "AppData");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", dbpath)));

//Configuração dos Serviços
builder.Services.AddScoped<IActorService, ActorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//Popular Base de Dados
using (var scope = app.Services.CreateScope())
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        Inicializacao.CriaDadosIniciais(db);
    }
    catch
    {
        throw;
    }

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
