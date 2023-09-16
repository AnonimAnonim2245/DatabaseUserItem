using DatabaseUserItem.Database;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var provider = builder.Services.BuildServiceProvider();
//var configuration = provider.GetService<IConfiguration>();

builder.Services.AddControllers();

//builder.Services.AddDbContext<TodoContext>(item => item.UseSqlServer(configuration.GetConnectionString("mycoon")));
builder.Services.AddDbContext<CompanyContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value));


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