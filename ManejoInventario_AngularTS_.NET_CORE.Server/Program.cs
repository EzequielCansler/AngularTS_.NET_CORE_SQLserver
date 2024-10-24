using ManejoInventario_AngularTS_.NET_CORE.Server.Repositories;
using ManejoInventario_AngularTS_.NET_CORE.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Desactiva el uso de camelCase
    });

// Agregar servicios al contenedor.


// Configurar el DbContext
builder.Services.AddDbContext<DB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<IPrioridadService, PrioridadService>();

builder.Services.AddScoped<IPrioridadRepository, PrioridadReporitory>();
builder.Services.AddScoped<ITareaRepository, TareaRepository>();
var app = builder.Build();



// Middleware para manejar archivos estáticos
app.UseDefaultFiles();
app.UseStaticFiles();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Descomentar si deseas habilitar Swagger en desarrollo
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configuración de CORS
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Mapear controladores
app.MapControllers();

// Esto permite manejar cualquier otra ruta que no sea capturada por los controladores
app.MapFallbackToFile("/index.html");

app.Run();
