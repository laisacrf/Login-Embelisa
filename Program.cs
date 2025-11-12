using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CondominioApp.Context;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// CONFIGURAÇÕES DE SERVIÇOS
// ===============================

// ✅ Suporte a controllers e views (MVC)
builder.Services.AddControllersWithViews();

// ✅ Suporte a sessões
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de sessão
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ✅ Banco de dados SQLite
builder.Services.AddDbContext<CondominioContext>(options =>
    options.UseSqlite("Data Source=Condominio.db")); 
    // o arquivo Condominio.db será criado automaticamente na pasta do projeto

// ===============================
// CONSTRUÇÃO DO APLICATIVO
// ===============================
var app = builder.Build();

// ===============================
// PIPELINE HTTP
// ===============================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Ativa sessão antes da autorização
app.UseSession();

app.UseAuthorization();

// ✅ Define a rota padrão do site
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Inicial}/{id?}"
);

app.Run();
