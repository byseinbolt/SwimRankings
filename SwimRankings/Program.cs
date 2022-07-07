using Microsoft.Extensions.DependencyInjection;

namespace SwimRankings;

public class Program
{
    public static void Main()
    {
        
        // Вывод всех имеющихся результатов каждого пловца
        using (var database = new SwimRankingsDbContext())
        {
            var swimmers = database.Swimmers.ToList();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All swimmers and their best results:\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (var swimmer in swimmers)
            {
                ShowSwimmerAllResults(swimmer.Name);
                Console.WriteLine();
            }
        }

        // Вывод всех имеющихся пловцов в базе данных (сначала мужчин, затем женщин)
        using (var database = new SwimRankingsDbContext())
        {
            var swimmers = database.Swimmers.OrderBy(swimmer => swimmer.Gender == 'F')
                .ThenBy(swimmer => swimmer.Gender == 'M');
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All swimmers:\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (var swimmer in swimmers)
            {
                var swimmerCountry = database.Countries.FirstOrDefault(country => country.Id == swimmer.CountryId);
                Console.WriteLine($"{swimmer.Name},{swimmer.Gender} - Country:{swimmerCountry.Name}");
            }
            Console.WriteLine();
        }
        

        // Вывод всех имеющихся пловцов в базе данных отсортированных по возрасту
        using (var database = new SwimRankingsDbContext())
        {
            var swimmers = database.Swimmers.OrderBy(swimmer => swimmer.YearOfBirth);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("All swimmers ordered by year of birth:\n");
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (var swimmer in swimmers)
            {
                var swimmerCountry = database.Countries.FirstOrDefault(country => country.Id == swimmer.CountryId);
                Console.WriteLine($"{swimmer.Name}, Gender: {swimmer.Gender}, Country: {swimmerCountry.Name}, YearOfBirth: {swimmer.YearOfBirth}");
            }
        }
        

         // Вывод спортсменов и их результатов на дистанциях вольным стилем
        using (var database = new SwimRankingsDbContext())
        {
            const string freestyle = "Freestyle";
            var freestyleDistances = database.Distances.Where(distance => distance.Stroke == freestyle);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAll swimmers results in freestyle:");
            Console.ForegroundColor = ConsoleColor.White;
            
            
            foreach (var freestyleDistance in freestyleDistances)
            {
                Console.WriteLine($"\n{freestyleDistance.Length}m {freestyleDistance.Stroke}:");
                
                var results = database.Results.Where(result => result.DistanceId == freestyleDistance.Id);
                
                foreach (var result in results)
                {
                    var swimmer = database.Swimmers.FirstOrDefault(swimmer => swimmer.Id == result.SwimmerId);
                    var country = database.Countries.FirstOrDefault(country => country.Id == swimmer.CountryId);
                    
                    Console.WriteLine($"{swimmer.Name}, {country.Name}, Best time: {result.Time}");
                }
            }
        }
        

       
    }
    
    private static void ShowSwimmerAllResults(string swimmerName)
    {
        var database = new SwimRankingsDbContext();
        var swimmer = database.Swimmers.FirstOrDefault(swimmer => swimmer.Name.Contains(swimmerName));
        var swimmerResults = database.Results.Where(result => result.SwimmerId == swimmer.Id);
        var swimmerCountry = database.Countries.FirstOrDefault(country => country.Id == swimmer.CountryId);
        
        Console.WriteLine($"{swimmer.Name}, {swimmerCountry.Name}");
        
        foreach (var result in swimmerResults)
        {
            var distance = database.Distances.FirstOrDefault(distance => distance.Id == result.DistanceId);
            
            Console.WriteLine($"{distance.Length}m {distance.Stroke}: {result.Time} ");
        }
    }
    
    
}