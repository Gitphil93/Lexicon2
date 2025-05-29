class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till huvudmenyn!");
            Console.WriteLine("Ange en siffra för att välja ett alternativ:");
            Console.WriteLine("1. Ungdom eller pensionär");
            Console.WriteLine("2. Gruppens biljettkostnad");
            Console.WriteLine("3. Upprepa text tio gånger");
            Console.WriteLine("4. Hämta det tredje ordet i en mening");
            Console.WriteLine("0. Avsluta");

            Console.Write("Val: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "0":
                    isRunning = false;
                    break;

                case "1":
                    CheckPrice();
                    break;

                case "2":
                    CalculateGroupPrice();
                    break;

                case "3":
                    Repeat();
                    break;

                case "4":
                    PrintThirdWord();
                    break;

                default:
                    StupidError();
                    Console.WriteLine("Felaktigt val. Tryck på valfri knapp för att försöka igen.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void CheckPrice()
    {
        Console.Write("Ange ålder: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            //age är alltid minst 0, men spelar nog ingen roll för funtionaliteten här
            age = Math.Max(age, 0);
            if (age < 5 || age > 100)
                Console.WriteLine("Pris: Gratis");
            else if (age < 20)
                Console.WriteLine("Ungdomspris: 80kr");
            else if (age > 64)
                Console.WriteLine("Pensionärspris: 90kr");
            else
                Console.WriteLine("Standardpris: 120kr");
        }
        else
        {
            StupidError();
            Console.WriteLine("Ogiltig ålder.");
        }

        PrintToMenu("");
        Console.ReadKey();
    }

    static void CalculateGroupPrice()
    {
        Console.Write("Hur många personer är ni? ");
        if (int.TryParse(Console.ReadLine(), out int antal))
        {
            int total = 0;
            for (int i = 1; i <= antal; i++)
            {
                Console.Write($"Ange ålder för person {i}: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    if (age < 5 || age > 100)
                        continue;
                    else if (age < 20)
                        total += 80;
                    else if (age > 64)
                        total += 90;
                    else
                        total += 120;
                }
                else
                {
                    Console.WriteLine("Ogiltig ålder.");
                }
            }

            Console.WriteLine($"Totalt antal personer: {antal}");
            Console.WriteLine($"Totalkostnad: {total}kr");
        }
        else
        {
            StupidError();
            Console.WriteLine("Ogiltigt antal.");
        }

        PrintToMenu("");
        Console.ReadKey();
    }

    static void Repeat()
    {
        Console.Write("Skriv in valfri text: ");
        string text = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(text))
    {
            StupidError();
        Console.WriteLine("Du måste skriva in något.");
    }
    else
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. {text} ");
        }
    }

        PrintToMenu("newLine");
        Console.ReadKey();
    }

    static void PrintThirdWord()
    {
        Console.Write("Skriv en mening med minst tre ord: ");
        string input = Console.ReadLine();

        // Delar upp strängen till ord i en array och hanterar extra mellanslag
        var word = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (word.Length >= 3)
        {
            Console.WriteLine($"Det tredje ordet är: {word[2]}");
        }
        else
        {
            StupidError();
            Console.WriteLine("Du måste skriva in minst tre ord.");
        }

        PrintToMenu("");
        Console.ReadKey();
    }

static void PrintToMenu(string newLine)
{
    string output = newLine == "newLine" ? "\nTryck på valfri knapp för att återgå till huvudmenyn." : "Tryck på valfri knapp för att återgå till huvudmenyn.";

    Console.WriteLine(output);
}

static void StupidError()
{
    string err = "error";

    for (int i = 0; i < err.Length; i++)
    {
        string result = "";

        for (int j = 0; j < err.Length; j++)
        {
            if (i == j)
                result += char.ToUpper(err[j]);
            else
                result += char.ToLower(err[j]);
        }

        Console.WriteLine(result);
    }
}
}
