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
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{Name} (Rarity: {Rarity}, Price: ${Price:F2}) - {Description}";
    }
}

public class NPC
{
    private Random random = new Random();
    private List<Fish> fishDatabase;

    public NPC()
    {
        fishDatabase = new List<Fish>
        {
            new Fish { Number = 1, Name = "araneacis", Rarity = FishRarity.Common, Description = "a fish with 8 fins and 2 stag beetles like pincers, they make good pets" },
            new Fish { Number = 2, Name = "sicmn", Rarity = FishRarity.Common, Description = "a black and white fish, looks skinny, almost like a skeleton, its patterns are used for shoes" },
            new Fish { Number = 3, Name = "pislique", Rarity = FishRarity.Common, Description = "a fish whose scales look like they are melting, usually used as a spice, it has a weird sweet and spicy taste" },
            new Fish { Number = 4, Name = "chocolate shark", Rarity = FishRarity.Rare, Description = "a shark that lives in swamps, its name comes from the pattern on its skin, it's toxic to eat" },
            new Fish { Number = 5, Name = "wuopod", Rarity = FishRarity.Rare, Description = "an octopus-like animal that has two main tentacles and 6 smaller ones. They like to make human faces out of kelp" },
            new Fish { Number = 6, Name = "crocodish", Rarity = FishRarity.Rare, Description = "a crocodile whose spikes look like a salad, a lot of people often eat them alive" }
        };
    }

    public Fish SellFish(int fishNumber)
    {
        var fish = fishDatabase.Find(f => f.Number == fishNumber);
        if (fish == null)
        {
            throw new ArgumentException("Invalid fish number.");
        }

        switch (fish.Rarity)
        {
            case FishRarity.Common:
                fish.Price = random.Next(500, 2001) / 100.0m;
                break;
            case FishRarity.Rare:
                fish.Price = random.Next(700, 4001) / 100.0m;
                break;
        }

        return fish;
    }
}

public class Program
{
    public static void Main()
    {
        NPC npc = new NPC();

        for (int i = 1; i <= 6; i++)
        {
            try
            {
                Fish fish = npc.SellFish(i);
                Console.WriteLine(fish);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
