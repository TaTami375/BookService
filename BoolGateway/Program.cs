using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Добавляем YARP
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Добавляем Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger на шлюзе
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // Проксируем Swagger-документацию BookService
    options.SwaggerEndpoint("https://localhost:5000/swagger/v1/swagger.json", "Book Service");
    options.RoutePrefix = "swagger";
});

app.MapReverseProxy();

app.Run();