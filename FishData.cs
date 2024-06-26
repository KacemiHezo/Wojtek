using System;
using System.Collections.Generic;

public enum FishRarity
{
    Common,
    Rare
}

public class Fish
{
    public int Number { get; set; }
    public string Name { get; set; }
    public FishRarity Rarity { get; set; }
    public string Description { get; set; }

    public Fish(int number, string name, FishRarity rarity, string description)
    {
        Number = number;
        Name = name;
        Rarity = rarity;
        Description = description;
    }
}

public class FishDatabase
{
    private List<Fish> fishList;

    public FishDatabase()
    {
        fishList = new List<Fish>
        {
            new Fish(1, "araneacis", FishRarity.Common, "A fish with 8 fins and 2 stag beetles like pincers, they make good pets"),
            new Fish(2, "sicmn", FishRarity.Common, "A black and white fish, looks skinny, almost like a skeleton, its patterns are used for shoes"),
            new Fish(3, "pislique", FishRarity.Common, "A fish whose scales look like they are melting, usually used as a spice, it has a weird sweet and spicy taste"),
            new Fish(4, "chocolate shark", FishRarity.Rare, "A shark that lives in swamps, its name comes from the pattern on its skin, it's toxic to eat"),
            new Fish(5, "wuopod", FishRarity.Rare, "An octopus-like animal that has two main tentacles and 6 smaller ones. They like to make human faces out of kelp"),
            new Fish(6, "crocodish", FishRarity.Rare, "A crocodile whose spikes look like a salad, a lot of people often eat them alive")
        };
    }

    public Fish GetFishByNumber(int fishNumber)
    {
        foreach (var fish in fishList)
        {
            if (fish.Number == fishNumber)
            {
                return fish;
            }
        }
        return null;
    }
}

public class Program
{
    public static void Main()
    {
        FishDatabase fishDatabase = new FishDatabase();

        int fishNumber = 3; // Example fish number

        Fish fish = fishDatabase.GetFishByNumber(fishNumber);

        if (fish != null)
        {
            Console.WriteLine($"Fish Name: {fish.Name}");
            Console.WriteLine($"Fish Rarity: {fish.Rarity}");
            Console.WriteLine($"Fish Description: {fish.Description}");
        }
        else
        {
            Console.WriteLine("Fish not found.");
        }
    }
}
