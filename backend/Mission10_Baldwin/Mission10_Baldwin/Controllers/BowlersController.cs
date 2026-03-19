using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Baldwin.Data;
using Mission10_Baldwin.Models;

namespace Mission10_Baldwin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlersController(BowlingLeagueContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BowlerResponse>>> GetBowlers()
    {
        var bowlers = await context.Bowlers // Query to get only the bowlers for the specified teams
            .Include(b => b.Team)
            .Where(b => b.Team != null && (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .OrderBy(b => b.BowlerLastName)
            .ThenBy(b => b.BowlerFirstName)
            .Select(b => new BowlerResponse
            {
                BowlerFirstName = b.BowlerFirstName,
                BowlerMiddleInit = b.BowlerMiddleInit,
                BowlerLastName = b.BowlerLastName,
                TeamName = b.Team!.TeamName,
                BowlerAddress = b.BowlerAddress,
                BowlerCity = b.BowlerCity,
                BowlerState = b.BowlerState,
                BowlerZip = b.BowlerZip,
                BowlerPhoneNumber = b.BowlerPhoneNumber
            })
            .ToListAsync();

        return Ok(bowlers);
    }
}
