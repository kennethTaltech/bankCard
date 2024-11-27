
public class Circle
{
    // Private fields for radius and diameter
    private double _radius;
    private double _diameter;

    // Method for setting the radius
    public void SetRadius(double radius)
    {
        if (radius <= 0)
        {
            Console.WriteLine("Radius must be a positive number.");
            return;
        }

        _radius = radius;
        _diameter = 2 * radius;
        PrintInfo();
    }

    // Method for setting the diameter
    public void SetDiameter(double diameter)
    {
        if (diameter <= 0)
        {
            Console.WriteLine("Diameter must be a positive number.");
            return;
        }

        _diameter = diameter;
        _radius = diameter / 2;
        PrintInfo();
    }

    // Method for printing info about radius and diameter
    public void PrintInfo()
    {
        if (_radius > 0 && _diameter > 0)
        {
            Console.WriteLine($"Circle radius is {_radius} and diameter is {_diameter}");
        }
        else
        {
            Console.WriteLine("Values are not set!");
        }
    }

    // Method for calculating and printing the area, rounded to 2 decimal places
    public void CalculateArea()
    {
        if (_radius > 0)
        {
            double area = Math.PI * _radius * _radius;
            Console.WriteLine($"The area of the circle is {Math.Round(area, 2)}");
        }
        else
        {
            Console.WriteLine("Cannot calculate area. Radius is not set.");
        }
    }

    // Method for calculating and printing the circumference, rounded to 2 decimal places
    public void CalculateCircumference()
    {
        if (_radius > 0)
        {
            double circumference = 2 * Math.PI * _radius;
            Console.WriteLine($"The circumference of the circle is {Math.Round(circumference, 2)}");
        }
        else
        {
            Console.WriteLine("Cannot calculate circumference. Radius is not set.");
        }
    }
}

// Main method for testing the Circle class
public class Program
{
    public static void Main()
    {

        Circle circle1 = new Circle();
        circle1.PrintInfo(); // Expected: "Values are not set!" because no radius or diameter has been assigned.
        circle1.SetRadius(4); // Expected: Sets radius to 4, diameter to 8, and prints info.
        circle1.SetRadius(-5); // Expected: Prints error message and does not set radius or diameter.
        circle1.CalculateArea(); // Expected: Prints area.
        circle1.CalculateCircumference(); // Expected: Prints circumference.


        Circle circle2 = new Circle();
        circle2.SetDiameter(10); // Expected: Sets diameter to 10, radius to 5, and prints info.
        circle2.CalculateArea(); // Expected: Prints area.
        circle2.CalculateCircumference(); // Expected: Prints circumference.

    }
}
