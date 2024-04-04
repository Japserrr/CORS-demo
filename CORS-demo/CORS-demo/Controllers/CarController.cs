using CORS_demo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CORS_demo.Controllers;

//[EnableCors("MyPolicy")] // You can add a CORS policy to a specific controller. The policy applies to all endpoints in the controller.
[Route("[controller]")] 
public class CarController : Controller
{
    private List<Car> cars = new() { 
        new Car("Ford", "Mustang", 2020),
        new Car("Audi", "A7", 2022),
        new Car("BMW", "M5", 2019),
    };

    //[EnableCors("MyPolicy")] // Or you can add a CORS policy to a specific endpoint
    [HttpGet]
    public IEnumerable<Car> Get() => cars;

    //[DisableCors] // You can still disable the GET and POST requests
    [HttpPost]
    public IEnumerable<Car> Post() => cars;

    //[EnableCors("MyGooglePolicy")]
    [HttpPut]
    public IEnumerable<Car> Put() => cars;

    [HttpPatch]
    public IEnumerable<Car> Patch() => cars;

    [HttpDelete]
    public IEnumerable<Car> Delete() => cars;
}
