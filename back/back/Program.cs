using back.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Conexao com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<NotaFiscalDbContext>(x => x.UseNpgsql(connectionString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
