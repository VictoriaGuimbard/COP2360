public class Octopus
{
  public readonly string Name;
  public readonly int Legs = 8;
  public int Age = 10;

  // Constructor to initialize the Name field
  public Octopus(string name)
  {
    Name = name;
  }

  // Nested class within Octopus
  public class Tentacle
  {
    public int Length { get; set; }
    public void DisplayLength()
    {
      Console.WriteLine($"Tentacle length is {Length} cm.");
    }
  }

  // Nested enum to describe octopus colors
  public enum Color
  {
    Red,
    Blue,
    Green
  }

  // Method to access the nested enum

public void DisaplyColor(Color color)
{
  Console.WriteLine($"The octopus color is {color}.");
}

class Program
{
  static void Main(String[] args)
  {
    // Instantiate Octopus class
    var o = new Octopus("Jack");

    // Access and display octopus properties
    Console.WriteLine($"The octopus's name is {o.Name}.");
    Console.WriteLine($"The octopus's age is {o.Age} years old.");
    Console.WriteLine($"The octopus has {o.Legs} legs.");

    // Create and use an istance of nested Tentacle class
    var tentacle = new Octopus.Tentacle();
    tentacle.Length = 50; // Set length of tentacles
    tentacle.DisplayLength(); // Display the length of the tentacle

    // Use nested Color enum
    o.DisplayColor(Octopus.Color.Red);

    // Modify and display Age
    o.Age = 12;
    Console.WriteLines($"The octopus's new age is {o.Age} years old.");
  }
}
