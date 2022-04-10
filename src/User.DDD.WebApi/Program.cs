using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.DDD.Application;
using User.DDD.Domain;
using User.DDD.Domain.Repositorys;
using User.DDD.Intrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<UserDbContext>(opt => {
    opt. UseSqlite("Data Source=data.db",o=>o.MigrationsAssembly("User.DDD.Intrastructure"));
  
   
});
builder.Services.AddMediatR(Assembly.Load("User.DDD.Application"));
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<IUserRepositrory, UserRepositrory>();
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodeSender>();
builder.Services.AddScoped<ILoginContract, LoginService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
