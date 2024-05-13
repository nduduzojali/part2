using System;
using System.Collections.Generic;

// Getting notified when a recipe exceeds 300 calories
delegate void RecipeCalorieNotification(Recipe recipe);

class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }

    public Recipe(string name)
    {
        Name = name;
        Ingredients = new List<Ingredient>();
        Steps = new List<string>();
    }

    public void AddIngredient(string name, double quantity, string unit, double calories, FoodGroup foodGroup)
    {
        Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
    }

    public void AddStep(string step)
    {
        Steps.Add(step);
    }

    public void Display()
    {
        Console.WriteLine($"Recipe: {Name}\n");

        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i]}");
        }
    }

    public double CalculateTotalCalories()
    {
        double totalCalories = 0;
        foreach (var ingredient in Ingredients)
        {
            totalCalories += ingredient.Calories;
        }
        return totalCalories;
    }
}

class Ingredient
{
    public string Name { get; }
    public double Quantity { get; set; }
    public string Unit { get; }
    public double Calories { get; }
    public FoodGroup FoodGroup { get; }

    public Ingredient(string name, double quantity, string unit, double calories, FoodGroup foodGroup)
    {
        Name = name;
        Quantity = quantity;
        Unit = unit;
        Calories = calories;
        FoodGroup = foodGroup;
    }
}

enum FoodGroup
{
    Grains,
    Vegetables,
    Fruits,
    Dairy,
    Protein,
    Fats,
    Sugars
}

class Program
{
    static List<Recipe> recipes = new List<Recipe>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Enter recipe details");
            Console.WriteLine("2. Display all recipes");
            Console.WriteLine("3. Select and display a recipe");
            Console.WriteLine("4. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid option. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    EnterRecipeDetails();
                    break;
                case 2:
                    DisplayAllRecipes();
                    break;
                case 3:
                    DisplaySelectedRecipe();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void EnterRecipeDetails()
    {
        Console.Write("Enter recipe name: ");
        string name = Console.ReadLine();

        Recipe recipe = new Recipe(name);

        Console.Write("Enter number of ingredients: ");
        int numOfIngredients;
        if (!int.TryParse(Console.ReadLine(), out numOfIngredients) || numOfIngredients <= 0)
        {
            Console.WriteLine("Invalid number of ingredients. Please try again.");
            return;
        }

        for (int i = 0; i < numOfIngredients; i++)
        {
            Console.WriteLine($"\nEnter details for ingredient {i + 1}:");
            Console.Write("Name: ");
            string ingredientName = Console.ReadLine();
            Console.Write("Quantity: ");
            double quantity;
            if (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please try again.");
                return;
            }
            Console.Write("Unit: ");
            string unit = Console.ReadLine();
            Console.Write("Calories: ");
            double calories;
            if (!double.TryParse(Console.ReadLine(), out calories) || calories <= 0)
            {
                Console.WriteLine("Invalid calories. Please try again.");
                return;
            }
            Console.Write("Food group (Grains, Vegetables, Fruits, Dairy, Protein, Fats, Sugars): ");
            FoodGroup foodGroup;
            if (!Enum.TryParse(Console.ReadLine(), true, out foodGroup))
            {
                Console.WriteLine("Invalid food group. Please try again.");
                return;
            }

            recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
        }

        Console.Write("\nEnter number of steps: ");
        int numOfSteps;
        if (!int.TryParse(Console.ReadLine(), out numOfSteps) || numOfSteps <= 0)
        {
            Console.WriteLine("Invalid number of steps. Please try again.");
            return;
        }

        for (int i = 0; i < numOfSteps; i++)
        {
            Console.WriteLine($"\nEnter step {i + 1}:");
            string step = Console.ReadLine();
            recipe.AddStep(step);
        }

        recipes.Add(recipe);
        Console.WriteLine("Recipe added successfully.");
    }

    static void DisplayAllRecipes()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));
        Console.WriteLine("All recipes:");
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    static void DisplaySelectedRecipe()
    {
        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            return;
        }

        Console.WriteLine("Select a recipe to display:");
        for (int i = 0; i < recipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {recipes[i].Name}");
        }

        int index;
        if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > recipes.Count)
        {
            Console.WriteLine("Invalid selection. Please try again.");
            return;
        }

        Recipe selectedRecipe = recipes[index - 1];
        selectedRecipe.Display();
        double totalCalories = selectedRecipe.CalculateTotalCalories();
        Console.WriteLine($"\nTotal Calories: {totalCalories}");
        if (totalCalories > 300)
        {
            Console.WriteLine("Warning: Total calories exceed 300!");
        }
    }

    // Method to handle notification when a recipe exceeds 300 calories
    static void NotifyCalorieExceedance(Recipe recipe)
    {
        Console.WriteLine($"Warning: Recipe '{recipe.Name}' exceeds 300 calories!");
    }
}

