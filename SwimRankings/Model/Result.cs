using System.ComponentModel.DataAnnotations;

namespace SwimRankings;

public class Result
{
    
    public int Id { get; set; }
    
    public int DistanceId { get; set; }
    public double Time { get; set; }
    
    public virtual int SwimmerId { get; set; }

    public Result(int distanceId, double time)
    {
        DistanceId = distanceId;
        Time = time;
    }
    
    
}