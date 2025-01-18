using Blip.Infraestructure;
using Blip.Infraestructure.CrossCutting.Ioc;
using Blip.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterServices();
builder.Services.ConfigureApiUrls();
builder.Services.AddHttpClient<GithubService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();