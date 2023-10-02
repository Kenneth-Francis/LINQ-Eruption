List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma",          2021, "Canary Is",   2426, "Stratovolcano"),
    new Eruption("Villarrica",        1963, "Chile",       2847, "Stratovolcano"),
    new Eruption("Chaiten",           2008, "Chile",       1122, "Caldera"),
    new Eruption("Kilauea",           2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla",             1206, "Iceland",     1490, "Stratovolcano"),
    new Eruption("Taupo",             1910, "New Zealand",  760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania",    2962, "Stratovolcano"),
    new Eruption("Santorini",           46, "Greece",       367, "Shield Volcano"),
    new Eruption("Katla",              950, "Iceland",     1490, "Subglacial Volcano"),
    new Eruption("Aira",               766, "Japan",       1117, "Stratovolcano"),
    new Eruption("Ceboruco",           930, "Mexico",      2280, "Stratovolcano"),
    new Eruption("Etna",              1329, "Italy",       3320, "Stratovolcano"),
    new Eruption("Bardarbunga",       1477, "Iceland",     2000, "Stratovolcano")
};


// QUERY 1 - Prints the first Chile eruption
Eruption firstChileEruption =
    eruptions   .Where(e => e.Location == "Chile")
                .OrderBy(e => e.Year)
                .First();

Console.WriteLine($"1. First Chile Eruption:{firstChileEruption}");


// QUERY 2 - Prints the first Hawaiian Is Eruption. If none, prints "No Hawaiian Is Eruption found."
Eruption? firstHawaiianIsEruption =
    eruptions   .Where(e => e.Location == "Hawaiian Is")
                .OrderBy(e => e.Year)
                .FirstOrDefault();

    if (firstHawaiianIsEruption != null)
    {
        Console.WriteLine($"2. First Hawaiian Is Eruption:{firstHawaiianIsEruption}");
    }
    else
    {
        Console.WriteLine("\n2. First Hawaiian Is Eruption:\nNo Hawaiian Is Eruption found.");
    }


// QUERY 3 - Prints the first Greenland Eruption. If none, prints "No Greenland Eruption found."
Eruption? firstGreenlandEruption =
    eruptions   .Where(e => e.Location == "Greenland")
                .OrderBy(e => e.Year)
                .FirstOrDefault();

    if (firstGreenlandEruption != null)
        Console.WriteLine($"3. First Greenland Eruption:{firstGreenlandEruption}");
    else
        Console.WriteLine("3. First Greenland Eruption:\n            No Greenland Eruption found.\n");


// QUERY 4 - Prints the first Eruption in New Zealand after 1900
Eruption firstNzEruptionAfter1900 =
    eruptions   .Where(e => e.Location == "New Zealand" && e.Year > 1900)
                .OrderBy(e => e.Year)
                .First();

    Console.WriteLine($"4. First NZ Eruption After 1900:{firstNzEruptionAfter1900}");


// QUERY 5 - Prints all Eruptions where the Volcano's Elevation is over 2000m
IEnumerable<Eruption> over2000Meters = eruptions.Where(e => e.ElevationInMeters > 2000);

    PrintEach(over2000Meters, "5. Eruptions from Volcanoes with greater than 2000m Elevation:");


// QUERY 6 - Prints all Eruptions where the Volcano's Name starts with 'L'
IEnumerable<Eruption> startsWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));

    PrintEach(startsWithL, "6. Eruptions from Volcanoes whose Name starts with L:");


// QUERY 7 - Prints the Integer of the Volcano with the highest Elevation
int highestElevation = eruptions.Max(e => e.ElevationInMeters);

    Console.WriteLine($"7. Highest Elevation of Erupted Volcanoes:\n            {highestElevation} meters");


// QUERY 8 - Prints the Volcano Name with the highest Elevation
Eruption highestVolcano = eruptions.First(e => e.ElevationInMeters == highestElevation);

    Console.WriteLine($"\n8. Volcano with greatest Elevation:\n            {highestVolcano.Volcano}");


// QUERY 9 - Prints all Volcano Names alphabetically
IEnumerable<Eruption> volcanoesOrdered = eruptions.OrderBy(e => e.Volcano);

    Console.WriteLine($"\n9. All Volcanoes Alphabetically:");
    foreach (Eruption e in volcanoesOrdered)
    {
        Console.WriteLine($"            {e.Volcano}");
    }


// QUERY 10 - Prints the Sum of all Volcano Elevations
int sumElevation = eruptions.Sum(e => e.ElevationInMeters);

    Console.WriteLine($"\n10. Elevation Sum:\n            {sumElevation} meters");


// QUERY 11 - Prints whether any Volcanoes erupted 
bool anyEruptionsIn2000 = eruptions.Any(e => e.Year == 2000);

    Console.WriteLine($"\n11. Any Volcano Eruptions in 2000?:\n             {anyEruptionsIn2000}");


// QUERY 12 - Prints the First Three Stratovolcanoes
IEnumerable<Eruption> firstThreeStratovolcanoes =
    eruptions   .Where(e => e.Type == "Stratovolcano")
                .Take(3);

    PrintEach(firstThreeStratovolcanoes, "12. First Three Stratovolcanoes:");


// QUERY 13 - Prints all Eruptions before 1000CE alphabetically
IEnumerable<Eruption> eruptionsBefore1000Alphabetically =
    eruptions   .Where(e => e.Year < 1000)
                .OrderBy(e => e.Volcano);
    PrintEach(eruptionsBefore1000Alphabetically, "13. All Eruptions before 1000CE alphabetically:");


// QUERY 14 - Prints all Eruptions before 1000CE alphabetically
IEnumerable<string> volcanoesBefore1000Alphabetically =
    eruptions   .Where(e => e.Year < 1000)
                .Select(e => e.Volcano)
                .OrderBy(e => e);
    
    Console.WriteLine("14. All Volcanoes that erupted before 1000CE alphabetically:");
    foreach (string e in volcanoesBefore1000Alphabetically)
    {
        Console.WriteLine($"            {e}");
    }




// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
