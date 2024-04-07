using WebApplication1.DataBase;

namespace WebApplication1.Endpoints;

public static class AnimalEndpoints
{
    // 200 - ok
    // 201 - created
    // 404 - not found
    
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        // retrieve a list of animals
        app.MapGet("/animals-minimalapi/", () =>
        {
            if (StataticData.animals.Any())
            {
                Console.WriteLine(StataticData.animals);
                return Results.Ok(StataticData.animals);
            }
    
            return Results.NotFound();
        });
        
        // retrieve a specific animal by id
        app.MapGet("/animals-minimalapi/{id}", (int id) =>
        {
            if (StataticData.animals.Any(animal => animal.Id == id))
            {
                Console.WriteLine(StataticData.animals.FirstOrDefault(a => a.Id == id));
                return Results.Ok(StataticData.animals.FirstOrDefault(a => a.Id == id));
            }
    
            return Results.NotFound();
        });

        // add an animal
        app.MapPost("/animals-minimalapi", (Animal animal) =>
        {
            Console.WriteLine(animal.Id);
            Console.WriteLine(animal.FirstName);
            StataticData.animals.Add(animal);
            
            return Results.Created($"/animals/{animal.Id}", animal);
        });
        
        // edit an animal
        app.MapPut("/animals-minimalapi/{id}", (int id, Animal update) => {
            
            var animal = StataticData.animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return Results.NotFound();
            }
            animal.FirstName = update.FirstName;
            animal.Category = update.Category;
            animal.Weight = update.Weight;
            animal.FurColor = update.FurColor;
            
            return Results.Ok(animal);
        });
        
        // delete an animal
        app.MapDelete("/animals/{id}", (int id) => 
        {
            var animal = StataticData.animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return Results.NotFound();
            }
            StataticData.animals.Remove(animal);
            return Results.Ok();
        });

        // retrieve a list of visits associated with a given animal
        app.MapGet("/animals/{animalId}/visits", (int animalId) =>
        {
            var animal = StataticData.animals.FirstOrDefault(a => a.Id == animalId);

            if (animal == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(StataticData.Visits.FirstOrDefault(v => v.AnimalID == animalId));
        });
        
        // add new visit
        app.MapPost("/animals/{animalId}/visits", (int animalId, Visit visit) => 
        {
            var animal = StataticData.animals.FirstOrDefault(a => a.Id == animalId);

            if (animal == null)
            {
                return Results.NotFound();
            }
            StataticData.Visits.Add(visit);
            return Results.Created($"/animals/{animalId}", visit);
        });
    }
}