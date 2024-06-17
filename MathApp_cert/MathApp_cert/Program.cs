using MathApp_cert;

Console.WriteLine("----------------------------------");
Console.WriteLine("-Witaj w programie dla studentów!-");
Console.WriteLine("----------------------------------");
Console.WriteLine("---(aby wyjść wprowadź q lub Q)---");
Console.WriteLine("----------------------------------");
Console.WriteLine();

Console.WriteLine("Podaj imię studenta: ");
var name = Console.ReadLine();

Console.WriteLine("Podaj nazwisko studenta: ");
var surname = Console.ReadLine();

var student01 = new StudentInFile(name, surname);
//var student01 = new StudentInMemory(name, surname);

student01.GradeAdded += StudentGradeAdded;

void StudentGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano nową ocenę");
}

while (true)
{
    Console.WriteLine($"Podaj kolejną ocenę dla {name} {surname} :");

    var input = Console.ReadLine();

    if (input == "q" || input == "Q")
    {
        break;
    }

    try
    {
        student01.AddGrade(input);
    }

    catch (Exception e)
    {
        Console.WriteLine($"Exception catched: {e.Message}");
    }

}

var statistic01 = student01.GetStatistics();

Console.WriteLine();
Console.WriteLine($"Wyniki dla pracownika {name} {surname} poniżej");
Console.WriteLine();
Console.WriteLine($"Średnia: {statistic01.Avg:N2}");
Console.WriteLine($"Min: {statistic01.Min}");
Console.WriteLine($"Max: {statistic01.Max}");
Console.WriteLine($"Ocena: {statistic01.AvgLetter}");
