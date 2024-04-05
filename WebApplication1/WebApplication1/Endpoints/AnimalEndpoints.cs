namespace WebApplication1.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals-minimalapi/{id}", (int id) =>
        {
            if (id != 1)
            {
                return Results.NotFound();
            }
    
            // Process data
            return Results.Ok();
        });

// 200 - ok
// 201 - created
// 404 - not found

        app.MapPost("/animals-minimalapi", (Animal animal) =>
        {
            Console.WriteLine(animal.id);
            Console.WriteLine(animal.firstName);
    
            if (false)
            {
                return Results.BadRequest();
            }
            return Results.Created();
        });
    }
}