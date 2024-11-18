using BL;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("colorsDB")));

DBActions actions = new DBActions(builder.Configuration);
var connstring = actions.GetConnectionString("colorsdb");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connstring));
builder.Services.AddScoped(b => new BLManager(connstring));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllPolicy");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.MapGet("/", () => "Hello World!");

app.Run();

