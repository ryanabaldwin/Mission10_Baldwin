namespace Mission10_Baldwin.Models;

public class BowlerResponse
{
    public string? BowlerFirstName { get; set; }
    public string? BowlerMiddleInit { get; set; }
    public string? BowlerLastName { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public string? BowlerPhoneNumber { get; set; }
}
