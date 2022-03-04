global using RealEstateAPI.Model;
global using RealEstateAPI.Data;
global using Microsoft.EntityFrameworkCore;
using RealEstateData.Data_Access;
using MediatR;
using RealEstateData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//add services for MediatR
builder.Services.AddTransient<IAgentDataAccess, AgentDataAccess>();
builder.Services.AddMediatR(typeof(RealEstateDataMediatREntryPoint).Assembly);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
