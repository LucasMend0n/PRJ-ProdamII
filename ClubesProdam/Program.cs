using ClubesProdam.Context;
using ClubesProdam.Repository;
using ClubesProdam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
builder.Services.AddDbContext<ClubeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(ClubeDbContext).Assembly.FullName));
});

builder.Services.AddCors(options =>
 {
     options.AddPolicy("AllowAnyServer",
         builder =>
         {
             builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });
 });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyServer");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
