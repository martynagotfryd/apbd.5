using WebApplication1;
using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// Minimal API

// app.MapGet("/weatherforecast", () =>
//     {
//         var forecast = Enumerable.Range(1, 5).Select(index =>
//                 new WeatherForecast
//                 (
//                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                     Random.Shared.Next(-20, 55),
//                     summaries[Random.Shared.Next(summaries.Length)]
//                 ))
//             .ToArray();
//         return forecast;
//     })
//     .WithName("GetWeatherForecast")
//     .WithOpenApi();
//
// app.MapGet("/animals-minimalapi/{id}", (int id) =>
// {
//     if (id != 1)
//     {
//         return Results.NotFound();
//     }
//     
//     // Process data
//     return Results.Ok();
// });
//
// // 200 - ok
// // 201 - created
// // 404 - not found
//
// app.MapPost("/animals-minimalapi", (Animal animal) =>
// {
//     Console.WriteLine(animal.id);
//     Console.WriteLine(animal.firstName);
//     
//     if (false)
//     {
//         return Results.BadRequest();
//     }
//     return Results.Created();
// });

app.MapAnimalEndpoints();

// Controllers
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}