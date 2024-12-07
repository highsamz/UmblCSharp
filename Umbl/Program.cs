using Microsoft.EntityFrameworkCore;
using Umbl.Data.Contexts; // Ajuste para o namespace correto do DatabaseContext
using Microsoft.Extensions.DependencyInjection;
using Umbl.Data.Repository;
using Umbl.Data.Repository.Umbl.Data.Repository;
using Umbl.Data.Contexts.Umbl.Data.Contexts; // Ajuste para o namespace correto do repositório

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados Oracle
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
);

// Registro do repositório IPontoColetaRepository e sua implementação
builder.Services.AddScoped<IPontoColetaRepository, PontoColetaRepository>();

// Adiciona os serviços do MVC (controladores e views)
builder.Services.AddControllers();

// Configura o Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // Certifica que o roteamento está ativado
app.UseAuthorization();

// Mapeia as rotas para os controladores
app.MapControllers();

app.Run();
