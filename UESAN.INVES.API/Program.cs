using Microsoft.EntityFrameworkCore;
using UESAN.INVES.CORE.Core.Interfaces;
using UESAN.INVES.CORE.Core.Services;
using UESAN.INVES.CORE.Infrastructure.Data;
using UESAN.INVES.CORE.Infrastructure.Repositories;
using UESAN.INVES.CORE.Infrastructure.Shared;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:9000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

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
builder.Services.AddScoped<INotificacionesService, NotificacionesService>();
builder.Services.AddScoped<IFormularioInvestigacionRepository, FormularioInvestigacionRepository>();
builder.Services.AddScoped<IFormularioInvestigacionService, FormularioInvestigacionService>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<AccesosService, AccesosService>();
builder.Services.AddScoped<IAccesosRepository, AccesosRepository>();
builder.Services.AddScoped<IAsignacionesRepository, AsignacionesRepository>();
builder.Services.AddScoped<IAsignacionesService, AsignacionesService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IPublicacionesGuardadasRepository, PublicacionesGuardadasRepository>();
builder.Services.AddScoped<IPublicacionesGuardadasService, PublicacionesGuardadasService>();
builder.Services.AddScoped<IPublicacionesRepository, PublicacionesRepository>();
builder.Services.AddScoped<IPublicacionesService, PublicacionesService>();
builder.Services.AddScoped<IFaqChatbotRepository, FaqChatbotRepository>();
builder.Services.AddScoped<IFaqChatbotService, FaqChatbotService>();


builder.Services.AddSharedInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<JwtServices>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var jwtSettings = config.GetSection("JWTSettings").Get<UESAN.INVES.CORE.Core.Settings.JWTSettings>();
    return new JwtServices(
        jwtSettings.SecretKey,
        jwtSettings.Issuer,
        jwtSettings.Audience,
        (int)jwtSettings.DurationInMinutes
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();

