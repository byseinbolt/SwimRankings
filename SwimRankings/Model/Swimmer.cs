using System.ComponentModel.DataAnnotations;

namespace SwimRankings;

public class Swimmer
{
   
    public int Id { get; set; }
    
    public string Name { get; set; }
    public char Gender { get; set; }
    public int YearOfBirth { get; set; }
    public int CountryId { get; set; }
    
    public  List<Result> Results { get; set; }


   public Swimmer(string name, char gender, int yearOfBirth, int countryId)
   {
       Name = name;
       Gender = gender;
       YearOfBirth = yearOfBirth;
       CountryId = countryId;
       Results = new List<Result>();
   }
   

}