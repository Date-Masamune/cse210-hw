public class Shape
{
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter
    public string GetColor()
    {
        return _color;
    }

    // Setter
    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method for polymorphism
    public virtual double GetArea()
    {
        return 0;
    }
}
