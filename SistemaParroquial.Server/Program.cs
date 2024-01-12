using SistemaParroquial.Repositories;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//Add-MyConnection
string strConnection = builder.Configuration.GetConnectionString("MyConnection")!;
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(strConnection));
//Add-Repositories
builder.Services.AddScoped<IMisaTipoRepository, MisaTipoRepository>();
builder.Services.AddScoped<IMisaMotivoRepository, MisaMotivoRepository>();
builder.Services.AddScoped<IMisaRootRepository, MisaRootRepository>();
builder.Services.AddScoped<INombresRootRepository, NombresRootRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opciones =>
{
    opciones.AddPolicy(name: "nuevaPolitica", polyce =>
    {
        polyce.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("nuevaPolitica");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
