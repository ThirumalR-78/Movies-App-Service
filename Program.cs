using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PocketCinemaAPIService.Controllers;
using PocketCinemaAPIService.Dao;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<DBContextClass>();

/*builder.Services.AddDbContext<DBContextClass>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/
/*options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));*/

/*builder.Services.AddScoped(provider =>
{
    var dependency = provider.GetRequiredService<DBContextClass>();
    return new MoviesController(dependency);
});*/

builder.Services.AddScoped(provider =>
{
    var dependency = provider.GetRequiredService<DBContextClass>();
    return new MoviesDao(dependency);
});

builder.Services.AddScoped(provider =>
{
    var dependency = provider.GetRequiredService<DBContextClass>();
    return new UserDao(dependency);
});

builder.Services.AddScoped(provider =>
{
    var dependency = provider.GetRequiredService<MoviesDao>();
    return new MoviesController(dependency);
});


var app = builder.Build();
//https://github.com/cornflourblue/dotnet-6-jwt-authentication-api/tree/master
//best related https://github.com/seanonline/asp.net-core-6-jwt-authentication/tree/main
//https://github.com/shahedbd/JWTAutD6/tree/main

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// custom jwt auth middleware
//app.UseMiddleware<JwtMiddleware>();


app.MapControllers();

app.Run();
