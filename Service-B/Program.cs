using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string serviceAUrl = Environment.GetEnvironmentVariable("SERVICE_A_URL") ?? "http://localhost:5001/hello";
var httpClient = new HttpClient();
app.MapGet("/call", async () =>
{
    var result = await httpClient.GetStringAsync(serviceAUrl);
    return $"Service B received: {result}";
});

app.Run();

