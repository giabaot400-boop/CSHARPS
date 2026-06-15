using DapperApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký Repository vào DI container
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Bật giao diện Swagger để test API
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Kích hoạt các API trong thư mục Controllers
app.MapControllers();

app.Run();