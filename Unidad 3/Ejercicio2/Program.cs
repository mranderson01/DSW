using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ejercicio2.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Ejercicio2.seguridadToken;

var builder = WebApplication.CreateBuilder(args);

//BASE DE DATOS GAMES y GENERO
builder.Services.AddDbContext<Ejercicio2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ejercicio2Context") ?? throw new InvalidOperationException("Connection string 'Ejercicio2Context' not found.")));


// Configuración de Entity Framework y Identity
builder.Services.AddDbContext<seguridadContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("seguEjercicio2")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<seguridadContext>()
    .AddDefaultTokenProviders();

// Servicios DE AUTENTICACION  
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwt:Issuer"],
        ValidAudience = builder.Configuration["jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:Key"]))
    };
});

builder.Services.AddScoped<TokenService>(); // O el alcance adecuado para tu aplicación
//builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.AddControllers(); 
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
