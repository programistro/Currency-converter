namespace Avalon.Converter.ViewModels;

public class Course
{
    public string Currency { get; set; }
    public float Price { get; set; }

    public Course(string currency, float price)
    {
        Currency = currency;
        Price = price;
    }
}
