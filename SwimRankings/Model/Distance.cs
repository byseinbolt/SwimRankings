using System.ComponentModel.DataAnnotations;

namespace SwimRankings;

public class Distance
{
    
    public int Id { get; set; }
    public string Stroke { get; set; }
    public int Length { get; set; }

    public Distance(string stroke, int length)
    {
        Stroke = stroke;
        Length = length;
    }
}