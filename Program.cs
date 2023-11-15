using Spectre.Console;
Random random = new Random();
int[] pole = null;

Console.WriteLine("Zadejte své křestní jméno: ");
string jmeno = Console.ReadLine();

while(true)
{
    var vyber = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title($"\nAhoj, {jmeno.ToLower()} chceš:")
            .PageSize(10)
            .AddChoices(new[] {
            "1) vygenerovat nové pole", "2) zobrazit obsah aktuálního pole", "3) zobrazit první a poslední z aktuálního pole",
            }));

    if (vyber == "1) vygenerovat nové pole")
    {
        Console.WriteLine("Napiš rozsah 2-5000");
        int rozsah = Convert.ToInt32(Console.ReadLine());
        if(rozsah < 2)
        {
            Console.WriteLine("Špatně zadaná hodnota");
            
        }
        else if (rozsah > 5000) 
        {
            Console.WriteLine("Špatně zadaná hodnota");
        }
        else
        {
            pole = new int[rozsah];
            for(int i = 0; i<rozsah; i++)
            {
                pole[i] = random.Next(0, 280);
            }
            Console.Clear();
            
        }
    }
    else if(vyber == "2) zobrazit obsah aktuálního pole")
    {
        foreach(int a in pole)
        {
            Console.WriteLine(a);
        }
        Console.WriteLine($"průměrná hodnota je: {pole.Average()}, maximální hodnota je: {pole.Max()}, minimální hodnota je: {pole.Min()}");
        
        Console.ReadKey();
        Console.Clear();
    }
    else if (vyber == "3) zobrazit první a poslední z aktuálního pole")
    {
        if(pole != null)
        {
            Console.WriteLine($"První hodnota je: {pole[pole.Length - pole.Length]}, poslední hodnota je {pole[pole.Length - 1]}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Chyba");
            Console.ResetColor();
        }
    }
    else 
    {
        Console.WriteLine("Chybička se vloudila");
        Console.Clear();
    }
}
