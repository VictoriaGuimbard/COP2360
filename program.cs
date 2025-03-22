using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a dictionary with string keys and string values
        Dictionary<string, string> mydictionary = new Dictionary<string, string>();
        // Alternatively, you can use a List<string> to allow multiple values per key, if you prefer.

        bool exit = false;

        while (!exit)
        {
            displayMenu();

            string userChoice;
            Console.WriteLine("Enter your letter from the menu choice");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "a":
                    Console.Write("Enter key: ");
                    string keyToAdd = Console.ReadLine();
                    Console.Write("Enter value: ");
                    string valueToAdd = Console.ReadLine();
                    if (!mydictionary.ContainsKey(keyToAdd))
                    {
                        mydictionary.Add(keyToAdd, valueToAdd);
                        Console.WriteLine("Entry added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Key already exists.");
                    }
                    break;

                case "b":
                    Console.WriteLine("All entries:");
                    foreach (var entry in mydictionary)
                    {
                        Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
                    }
                    break;

                case "c":
                    Console.Write("Enter key to remove: ");
                    string keyToRemove = Console.ReadLine();
                    if (mydictionary.Remove(keyToRemove))
                    {
                        Console.WriteLine("Entry removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;

                case "d":
                    Console.Write("Enter new key: ");
                    string newKey = Console.ReadLine();
                    Console.Write("Enter new value: ");
                    string newValue = Console.ReadLine();

                    if (!mydictionary.ContainsKey(newKey))
                    {
                        mydictionary.Add(newKey, newValue);
                        Console.WriteLine("New entry added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Key already exists.");
                    }
                    break;

                case "e":
                    Console.WriteLine("Add a Value to an Existing Key");
                    Console.Write("Enter the key to which you want to add a value: ");
                    string existingKey = Console.ReadLine();
                    if (mydictionary.ContainsKey(existingKey))
                    {
                        Console.Write("Enter the value to append: ");
                        string valueToAppend = Console.ReadLine();
                        mydictionary[existingKey] += " " + valueToAppend; // Append the value to the existing value
                        Console.WriteLine("Value added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Key not found.");
                    }
                    break;

                case "f":
                    Console.WriteLine("Sort the Keys.");
                    var sortedDictionary = new SortedDictionary<string, string>(mydictionary);
                    Console.WriteLine("Sorted Entries:");
                    foreach (var entry in sortedDictionary)
                    {
                        Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void displayMenu()
    {
        Console.WriteLine("\n------------------Menu options-----------------------");
        Console.WriteLine("a. Populate the Dictionary.");
        Console.WriteLine("b. Display Dictionary Contents.");
        Console.WriteLine("c. Remove a key.");
        Console.WriteLine("d. Add a New Key and Value.");
        Console.WriteLine("e. Add a Value to an Existing Key.");
        Console.WriteLine("f. Sort the Keys.\n");
        Console.WriteLine("---------------------------------------");
    }
}
