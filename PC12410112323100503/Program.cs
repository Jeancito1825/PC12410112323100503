var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Registrar DbContext de EF Core usando la cadena de conexión de appsettings.json
builder.Services.AddDbContext<PC12410112323100503.Entidades.TallerContext>(options =>
    Microsoft.EntityFrameworkCore.SqlServerDbContextOptionsExtensions.UseSqlServer(options, builder.Configuration.GetConnectionString("TallerConnection")));

// Registrar dependencias del repository/service
builder.Services.AddScoped<PC12410112323100503.Core.Interfaces.IOrdenServicioRepository, PC12410112323100503.CORE.Infraestructure.Repositories.OrdenServicioRepository>();
builder.Services.AddScoped<PC12410112323100503.Core.Interfaces.IOrdenServicioService, PC12410112323100503.CORE.Infraestructure.Services.OrdenServicioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Show detailed exceptions in Development to help diagnose crashes
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
