using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();

// Adiciona o middleware do Prometheus para expor métricas
app.UseMetricServer();
app.UseHttpMetrics();

// Define a simple GET endpoint that returns "Hello from .NET REST"
app.MapGet("/hello", () => "Hello from .NET REST")
    .WithName("GetHello")
    .WithOpenApi();

app.Run();