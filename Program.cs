Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'.");

string[] products = new string[0];
int index = 0;

while (true)
{
    Console.Write("Ange produkt: ");
    string input = Console.ReadLine();

    // Nivå 3: accept exit in different forms
    if (input.Trim().ToLower() == "exit")
    {
        break;
    }

    input = input.Trim();

    // Check empty input
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du får inte ange ett tomt värde");
        Console.ResetColor();
        continue;
    }

    string[] parts = input.Split('-');

    if (parts.Length != 2)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på vänstra delen av produktnumret");
        Console.ResetColor();
        continue;
    }

    string leftPart = parts[0].Trim();
    string rightPart = parts[1].Trim();


    // Check left part is not empty
    if (string.IsNullOrWhiteSpace(leftPart))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på vänstra delen av produktnumret");
        Console.ResetColor();
        continue;
    }

    // Check left part contains only letters
    bool onlyLetters = true;

    foreach (char ch in leftPart)
    {
        if (!char.IsLetter(ch))
        {
            onlyLetters = false;
            break;
        }
    }

    if (!onlyLetters)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på vänstra delen av produktnumret");
        Console.ResetColor();
        continue;
    }

    // Check right part is an integer
    bool isNumber = int.TryParse(rightPart, out int productNumber);

    if (!isNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Felaktigt format på högra delen av produktnumret");
        Console.ResetColor();
        continue;
    }

    // Check range 200 - 500
    if (productNumber < 200 || productNumber > 500)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Den numeriska delen måste vara mellan 200 och 500");
        Console.ResetColor();
        continue;
    }

    // Nivå 2:
    // Array.Resize(ref products, index + 1);
    // products[index] = input.Trim();
    // index++;

    // Nivå 3: save only valid product
    Array.Resize(ref products, index + 1);
    products[index] = leftPart.ToUpper() + "-" + productNumber;
    index++;
}

// Sort products
Array.Sort(products);

Console.WriteLine();
Console.WriteLine("Du angav följande produkter (sorterade):");

foreach (string product in products)
{
    Console.WriteLine("* " + product);
}

Console.ReadLine();