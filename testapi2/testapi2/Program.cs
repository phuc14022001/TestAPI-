using Microsoft.EntityFrameworkCore;
using testapi2.Data;
using testapi2.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<MyDbConText>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Mydb"));
});

builder.Services.AddScoped<IPhong,PhongService>();
builder.Services.AddScoped<ITang, TangService>();

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
