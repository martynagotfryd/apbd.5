namespace WebApplication1;

public class Animal
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public List<Visit> Visits { get; set; } = new List<Visit>();

}