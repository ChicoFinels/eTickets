using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuração do DbContext
var dbpath = Path.Combine(Directory.GetCurrentDirectory(), "AppData");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", dbpath)));

//Configuração dos Serviços
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IDiretorService, DiretorService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();

builder.Services.AddIdentity<Utilizador, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Filmes}/{action=Index}/{id?}");

Inicializacao.SeedUsersAndRolesAsync(app).Wait();

app.Run();
