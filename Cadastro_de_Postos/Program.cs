using Cadastro_de_Postos.Repositories;
using Cadastro_de_Postos.Repositories.Interfaces;
using Cadastro_de_Postos.Services;
using Cadastro_de_Postos.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services
    .AddSingleton<IRepository, Repository>()
    .AddSingleton<IService, Service>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
