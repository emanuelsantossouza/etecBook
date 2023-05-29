using EtecBookApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conn =builder.Configuration.GetConnectionString("etecbookdb");

var server = ServerVersion.AutoDetect(conn);
builder.Services.AddDbContext<AppDbContext>(options =>{
    options.UseMySql(conn, server);
});

builder.Services.AddCors(options =>
    options.AddPolicy("MyPolicy", builder =>{
        builder.AllowAnyMethod().
        AllowAnyHeader()
        .AllowAnyOrigin();
    })
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();


app.Run();
