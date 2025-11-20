using NumberWordAnalyzer.Application.Interfaces;
using NumberWordAnalyzer.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MemoryCache for caching
builder.Services.AddMemoryCache();

// Add logging
builder.Services.AddLogging();

// Register the service with DI
builder.Services.AddScoped<INumberWordAnalyzerService, NumberWordAnalyzerService>();

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
