using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProdutoAPI2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(); // Para APIs
builder.Services.AddControllersWithViews(); // Para habilitar views
builder.Services.AddHttpClient(); // Adiciona suporte para HttpClient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
// );

app.UseHttpsRedirection();

//add
app.UseStaticFiles();

app.UseRouting();
//fim

app.UseAuthorization();

//app.MapControllers();

// Configuração das rotas
app.MapControllers(); // Para APIs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Exibir}/{action=Index}/{id?}"); // Ajuste para o seu controlador


app.Run();


//PARA ACESSAR A PAGINA DE LISTAGEM DE PRODUTOS ACESSAR A URL "https://localhost:7187/exibir"
