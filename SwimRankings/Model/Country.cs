using System.ComponentModel.DataAnnotations;

namespace SwimRankings;

public class Country
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Swimmer> Swimmers { get; set; }

    
    public Country(string name)
    {
        Name = name;
        Swimmers = new List<Swimmer>();
    }


}