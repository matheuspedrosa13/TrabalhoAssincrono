using Microsoft.OpenApi.Models;
using TrabalhoDaniel.Infra.Services;
using TrabalhoDaniel.Service.Services;
using TrabalhoDaniel.Repo.Repositories;
using Microsoft.Graph;

var builder = WebApplication.CreateBuilder(args);

// Adicione os serviços ao contêiner.
builder.Services.AddControllers();
// Adiciona HttpClient
builder.Services.AddHttpClient<HttpService>();
// Adiciona repositórios e serviços
builder.Services.AddScoped<IRepository<string>, Repository>();
builder.Services.AddScoped<IService, Service>();
// Configura o Swagger para documentação da API.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrabalhoDaniel API", Version = "v1" });
});

var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithMethods("GET");
    });
});

// Configura o pipeline de processamento de solicitações HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrabalhoDaniel API V1");
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
