using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// ��������� YARP
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// �������� Swagger �� �����
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    // ���������� Swagger-������������ BookService
    options.SwaggerEndpoint("https://localhost:5000/swagger/v1/swagger.json", "Book Service");
    options.RoutePrefix = "swagger";
});

app.MapReverseProxy();

app.Run();