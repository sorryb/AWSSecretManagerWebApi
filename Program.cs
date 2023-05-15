using TestSecretManagerWebApi;
using TestSecretManagerWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddAmazonSecretsManager("eu-west-2", "dev/testApp/webCredentials"); // ("eu-west-3", "development/TestSecretManagerWebApi/Credentials");

builder.Services.Configure<MyApiCredentials>(builder.Configuration);

builder.Services.AddScoped<MyService>();

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
