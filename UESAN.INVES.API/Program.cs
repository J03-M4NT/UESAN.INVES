using Microsoft.EntityFrameworkCore;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Core.Services;
using UESAN.INVES.CORE.Infrastructure.Data;
using UESAN.INVES.CORE.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
// Add dbcontext
builder.Services.AddDbContext<VdiIntranetContext>(options => options.UseSqlServer(connectionString));

//TODO: Add interfaces
builder.Services.AddScoped<IAccesosRepository, AccesosRepository>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IAsignacionesService, AsignacionesService>();
builder.Services.AddScoped<IAsignacionesRepository, AsignacionesRepository>();
builder.Services.AddScoped<INotificacionesRepository, NotificacionesRepository>();
builder.Services.AddScoped<IFormularioInvestigacionRepository, FormularioInvestigacionRepository>();
builder.Services.AddScoped<IFormularioInvestigacionService, FormularioInvestigacionService>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();


builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
