using LojaApi.Repositories;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services;
using LojaApi.Services.Interfaces;
using LojaAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddSingleton<ICategoriaRepository, CategoriaRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();