Console.WriteLine("Skriv in produkter. Avsluta med att skriva 'exit'.");

string[] products = new string[0];
int index = 0;

while (true)
{
    string input = Console.ReadLine();

    if (input.ToLower().Trim() == "exit")
    {
        break;
    }

    Array.Resize(ref products, index + 1);
    products[index] = input;
    index++;
}

Console.WriteLine();
Console.WriteLine("Du angav följande produkter:");

foreach (string product in products)
{
    Console.WriteLine("* " + product);
}

Console.ReadLine();