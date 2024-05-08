using EsportsPortal.Infrastructure.EFCore;
using EsportsPortal.Infrastructure.Email;
using EsportsPortal.Models.Users;
using EsportsPortal.Services;
using EsportsPortal.WebApi.Identity;
using EsportsPortal.WebApi.OpenApi;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EsportsPortalDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EsportsPortal")));

builder.Services.AddEmailSender(builder.Configuration);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>(o => o.SignIn.RequireConfirmedEmail = true)
    .AddRoles<UserRole>()
    .AddEntityFrameworkStores<EsportsPortalDbContext>();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddHttpLogging(
    options =>
    {
        options.LoggingFields = HttpLoggingFields.All;
        options.CombineLogs = true;
    });

builder.Services.AddControllers();

builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(c =>
    c.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapUserEndpoints();

app.MapControllers();

app.Run();
