using CCE.Application.Repositories.Usine;
using CCE.Infrastructure.Persistence.Context;
using CCE.Infrastructure.Persistence.Repositories.UsineRepository;
using Microsoft.EntityFrameworkCore;
using CST.CCE.EndPoints; // Import your endpoints namespace
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cee.cst")));
builder.Services.AddScoped<IUsineRepository, UsineRepository>();
builder.Services.AddScoped<IAtelierRepository, AtelierRepository>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

