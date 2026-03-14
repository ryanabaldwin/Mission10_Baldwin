using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission10_Baldwin.Models;

[Table("Bowlers")]
public class Bowler
{
    [Key]
    [Column("BowlerID")]
    public int BowlerId { get; set; }

    [Column("BowlerLastName")]
    public string? BowlerLastName { get; set; }

    [Column("BowlerFirstName")]
    public string? BowlerFirstName { get; set; }

    [Column("BowlerMiddleInit")]
    public string? BowlerMiddleInit { get; set; }

    [Column("BowlerAddress")]
    public string? BowlerAddress { get; set; }

    [Column("BowlerCity")]
    public string? BowlerCity { get; set; }

    [Column("BowlerState")]
    public string? BowlerState { get; set; }

    [Column("BowlerZip")]
    public string? BowlerZip { get; set; }

    [Column("BowlerPhoneNumber")]
    public string? BowlerPhoneNumber { get; set; }

    [Column("TeamID")]
    public int? TeamId { get; set; }

    public Team? Team { get; set; }
}
