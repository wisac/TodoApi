using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ITodoRepo, TodoRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

// build connection string
var connStringBuilder = new SqlConnectionStringBuilder()
{
   ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"),
   UserID = builder.Configuration["UserId"],
   Password = builder.Configuration["Password"]
};

builder.Services.AddDbContext<TodoDbContext>(opt =>
   opt.UseSqlServer(connStringBuilder.ConnectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}
 

app.MapControllers();

// app.UseHttpsRedirection();


app.Run();
