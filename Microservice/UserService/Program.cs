using Infrastructure.Core;
using Infrastructure.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommon();
builder.Services.AddCore(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwagger(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCommon();
app.UseSwagger(app.Configuration);
app.UseAuthorization();

app.UseCore();

app.Run();
