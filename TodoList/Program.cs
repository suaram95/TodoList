using static System.Console;
var isRunning = true;

var todos = new List<string>();

while (isRunning)
{
    var userInput = GetUserInput();

    if (!CheckForValidInput(userInput))
    {
        WriteLine("Invalid choice!\n");
        continue;
    }

    switch (userInput.ToUpperInvariant())
    {
        case "S":
            SeeAllTodos();
            break;
        case "A":
            AddNewTODO();
            break;
        case "R":
            RemoveTODO();
            break;
        case "E":
            WriteLine("Selected option: [E]xit");
            WriteLine("Exiting programm...");
            isRunning = false;
            break;
    }
}

// Method to get user input
static string? GetUserInput()
{
    WriteLine("Hello!");
    WriteLine("What do you want to do?");
    WriteLine("[S]ee all TODOs");
    WriteLine("[A]dd a TODO");
    WriteLine("[R]emove a TODO");
    WriteLine("[E]xit");

    var userInput = Console.ReadLine();
    return userInput;
}

// Method to check if user input is valid
bool CheckForValidInput(string? input)
{
    var option = input?.ToUpperInvariant() ?? "";

    return option == "S" ||
        option == "A" ||
        option == "R" ||
        option == "E";
}

// Method to see all todos
void SeeAllTodos()
{
    WriteLine("Selected option: [S]ee all TODOs");

    if (todos.Count == 0)
    {
        WriteLine("No TODOs found.\n");
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            WriteLine($"{i + 1}. {todos[i]}\n");
        }
    }
}


// Method to add a new todo
void AddNewTODO()
{
    var validDescription = false;
    do
    {
        WriteLine("Selected option: [A]dd a TODO");
        WriteLine("Provide TODO description: ");
        string todoDescription = Console.ReadLine();

        if (!IsValidDescription(todoDescription))
        {
            Console.WriteLine("Invalid TODO description,Please try again!");
            continue;
        }
        if (todos.Contains(todoDescription, StringComparer.OrdinalIgnoreCase))
        {
            WriteLine("TODO already exists. Add another one\n");
            break;
        }
        todos.Add(todoDescription);
        validDescription = true;
        WriteLine("TODO added successfully!\n");            
    } while (!validDescription);
}

bool IsValidDescription(string? todoDescription)
{
    return !string.IsNullOrWhiteSpace(todoDescription);
}

// Method to remove a todo
void RemoveTODO()
{
    if (todos.Count == 0)
    {
        WriteLine("No TODOs found.\n");
        return;
    }

    WriteLine("Selected option: [R]emove a TODO");

    SeeAllTodos();
    WriteLine("Enter the TODO number to remove:");

    if (!int.TryParse(ReadLine(), out int number) ||
        number < 1 || number > todos.Count)
    {
        WriteLine("Invalid TODO number. Please try again.\n");
        return;
    }

    todos.RemoveAt(number - 1);
    WriteLine("TODO removed successfully!");
}