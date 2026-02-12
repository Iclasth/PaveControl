using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PaveControl.Data;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot" // Força o .NET a entender quem é a pasta raiz
});
// Add services to the container.
builder.Services.AddControllersWithViews();

// DbContext configuration
builder.Services.AddDbContext<PaveControlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaveControlConnection")));

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue; // Permite arquivos grandes
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Pega o seu contexto de banco de dados
        var context = services.GetRequiredService<PaveControlDbContext>();

        // Comando que força a criação do banco e das tabelas na Azure
        context.Database.Migrate();

        Console.WriteLine("Banco de dados sincronizado com sucesso!");
    }
    catch (Exception ex)
    {
        // Se houver erro, ele será ignorado para o site não travar
        Console.WriteLine("Erro ao sincronizar banco: " + ex.Message);
    }
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
