using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission10_Baldwin.Models;

// Model for the Team table
[Table("Teams")]
public class Team
{
    [Key]
    [Column("TeamID")]
    public int TeamId { get; set; }

    [Column("TeamName")]
    public string TeamName { get; set; } = string.Empty;

    [Column("CaptainID")]
    public int? CaptainId { get; set; }

    public ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();
}
