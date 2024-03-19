namespace CORS_demo.Models;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string brand, string model, int year)
    {
        Id = Guid.NewGuid();
        Brand = brand;
        Model = model;
        Year = year;
    }
}
