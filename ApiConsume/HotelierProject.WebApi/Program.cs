using HotelierProject.DataAccess.Concrete;
using HotelierProject.DataAccess.Interceptors;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<AuditDbContextInterceptor>();

builder.Services.AddDbContext<AppDbContext>((sp,options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.AddInterceptors(sp.GetRequiredService<AuditDbContextInterceptor>());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
}

app.UseHttpsRedirection();

app.Run();
