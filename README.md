Part 2
Recipe Management System

This ReadMe file provides an overview of the Recipe Management System system.

## Features
1. **Enter Recipe Details:** This feature allows users to input details for a new recipe, including its name, ingredients, and steps.
2. **Display All Recipes:** Users can view a list of all available recipes sorted alphabetically by name.
3. **Select and Display a Recipe:** Users can choose a specific recipe from the list and display its details, including ingredients, steps, and total calories. If the total calories exceed 300, a warning message is displayed.
4. **Scale a Recipe:** This functionality enables users to scale a selected recipe by a factor of 0.5 (half), 2 (double), or 3 (triple) its original quantity.

## Usage
1. **Enter Recipe Details:** To add a new recipe, users should choose option 1. They will then be prompted to enter details such as the recipe name, number of ingredients, details for each ingredient (name, quantity, unit, calories, food group), and number of steps.
2. **Display All Recipes:** By selecting option 2, users can view a list of all available recipes. The list is displayed in alphabetical order.
3. **Select and Display a Recipe:** Option 3 allows users to select a recipe from the displayed list, view its details, and see the total calories. If the total calories exceed 300, a warning message is shown.
4. **Scale a Recipe:** Users can choose option 4 to scale a selected recipe. They need to choose a scaling factor (0.5 for half, 2 for double, or 3 for triple) and confirm the scaling operation.

## Instructions
- When entering ingredient details, users should ensure to provide valid inputs for quantity, calories, and select the appropriate food group from the given options.
- Invalid inputs will prompt error messages, and users will be asked to re-enter the information to ensure data integrity and accuracy.

## Note
- A noteworthy feature of the program is that it warns users if the total calories of a recipe exceed 300. This feature promotes awareness of nutritional content.

## Developer Notes
- The program employs a simple console-based interface for user interaction, ensuring ease of use and accessibility.
- Recipe data is stored in memory during runtime and is not persisted beyond the execution of the program.

## Dependencies
- The program is written in C# and relies on the .NET framework.
- It utilizes standard namespaces such as `System` and `System.Collections.Generic` for basic functionalities.

## Contributors
- [Your Name] (Replace with contributors' names if applicable)

