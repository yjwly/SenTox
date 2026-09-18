using SenToxRepository.Base;
using SenToxService.Base;
using SqlSugar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//读取连接字符串
string connStr = builder.Configuration.GetConnectionString("DefaultConnection")!;

//注册SqlSugar单例
builder.Services.AddSingleton<ISqlSugarClient>(_ => SugarConfig.GetInstance(connStr));

//注册泛型仓储、泛型服务
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
