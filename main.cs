using System;
using System.Collections.Generic;

public class Contractor
{
    // Fields
    private string name;
    private int number;
    private DateTime startDate;

    // Default constructor
    public Contractor()
    {
        name = "Unknown";
        number = 0;
        startDate = DateTime.MinValue;
    }

    // Parameterized constructor
    public Contractor(string name, int number, DateTime startDate)
    {
        this.name = name;
        this.number = number;
        this.startDate = startDate;
    }

    // Accessors
    public string GetName() => name;
    public int GetNumber() => number;
    public DateTime GetStartDate() => startDate;

    // Mutators
    public void SetName(string name) => this.name = name;
    public void SetNumber(int number) => this.number = number;
    public void SetStartDate(DateTime startDate) => this.startDate = startDate;

    // Optional: for display
    public override string ToString()
    {
        return $"Contractor Name: {name}, Number: {number}, Start Date: {startDate.ToShortDateString()}";
    }
}

// Subcontractor class inherits Contractor
public class Subcontractor : Contractor
{
    // Fields
    private int shift; // 1 = day, 2 = night
    private double hourlyPayRate;

    // Default constructor
    public Subcontractor() : base()
    {
        shift = 1;
        hourlyPayRate = 0.0;
    }

    // Parameterized constructor
    public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyPayRate)
        : base(name, number, startDate)
    {
        this.shift = shift;
        this.hourlyPayRate = hourlyPayRate;
    }

    // Accessors
    public int GetShift() => shift;
    public double GetHourlyPayRate() => hourlyPayRate;

    // Mutators
    public void SetShift(int shift) => this.shift = shift;
    public void SetHourlyPayRate(double rate) => this.hourlyPayRate = rate;

    // Calculate pay with shift differential
    public float CalculatePay(float hoursWorked)
    {
        double pay = hourlyPayRate * hoursWorked;
        if (shift == 2) // Night shift gets 3% more
        {
            pay *= 1.03;
        }
        return (float)pay;
    }

    // For display
    public override string ToString()
    {
        string shiftName = (shift == 1) ? "Day" : "Night";
        return base.ToString() + $", Shift: {shiftName}, Hourly Rate: ${hourlyPayRate:F2}";
    }
}

public class Program
{
    // Entry point
    public static void Main(string[] args)
    {
        List<Subcontractor> subcontractors = new List<Subcontractor>();
        string input;

        do
        {
            Console.WriteLine("\n--- Create New Subcontractor ---");

            Console.Write("Enter contractor name: ");
            string name = Console.ReadLine();

            Console.Write("Enter contractor number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Enter start date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter shift (1 = Day, 2 = Night): ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Enter hourly pay rate: ");
            double hourlyPayRate = double.Parse(Console.ReadLine());

            Console.Write("Enter hours worked: ");
            float hoursWorked = float.Parse(Console.ReadLine());

            // Create a new subcontractor
            Subcontractor sc = new Subcontractor(name, number, startDate, shift, hourlyPayRate);

            subcontractors.Add(sc);

            // Display info and total pay
            Console.WriteLine("\n" + sc.ToString());
            Console.WriteLine($"Total Pay: ${sc.CalculatePay(hoursWorked):F2}");

            Console.Write("\nAdd another subcontractor? (yes/no): ");
            input = Console.ReadLine().ToLower();

        } while (input == "yes");

        Console.WriteLine("\nProgram complete. Press any key to exit.");
        Console.ReadKey();
    }
}
