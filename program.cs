using integ1.Controllers;
using integ1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer( 
		builder.Configuration.GetConnectionString("DefaultConnection")));

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



