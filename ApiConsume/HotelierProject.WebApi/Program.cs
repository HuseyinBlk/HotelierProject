using FluentValidation;
using FluentValidation.AspNetCore;
using HotelierProject.Business.Extensions;
using HotelierProject.Business.Validators.RoomValidators;
using HotelierProject.DataAccess.Extensions;
using HotelierProject.WebApi.Etensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateRoomValidator>();

builder.Services.AddOpenApi();


builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddCustomCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
}

app.UseHttpsRedirection();
app.UseCors(CorsServiceExtensions.DefaultCorsPolicy);
app.UseAuthorization();
app.MapControllers();

app.Run();
