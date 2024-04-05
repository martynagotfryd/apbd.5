using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataBase;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = StataticData.animals;
        return Ok();
    }
}