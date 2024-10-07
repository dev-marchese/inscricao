using Inscricao.Business;
using Inscricao.Data;
using Inscricao.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adicionando serviços ao container.

builder.Services.AddConnection(builder.Configuration);
builder.Services.AddRazorPages();

builder.Services.AddScoped<IAlunoRepo, AlunoRepo>();
builder.Services.AddScoped<AlunoBs>();

builder.Services.AddScoped<IAlunoMatriculaRepo, AlunoMatriculaRepo>();
builder.Services.AddScoped<AlunoMatriculaBs>();

builder.Services.AddScoped<ICursoRepo, CursoRepo>();
builder.Services.AddScoped<CursoBs>();

var app = builder.Build();

//Criando um escopo para o DbContext
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ConnectionDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //páginas Razor
    //endpoints.MapRazorPages();

    //controladores
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
