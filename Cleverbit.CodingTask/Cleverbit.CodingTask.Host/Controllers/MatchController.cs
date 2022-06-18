using Cleverbit.CodingTask.Application.Match;
using Cleverbit.CodingTask.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        /// <summary>
        /// Gets the winners' results from all the matches.
        /// </summary>
        /// <returns>List of Matches results</returns>
        [HttpGet("results")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMatchesResultsAsync() =>
            Ok(await _matchService.GetMatchesWinnersAsync());

        /// <summary>
        /// Get info/statistics of the current match.
        /// </summary>
        /// <returns>Number generated.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCurrentMatchAsync()
        {
            try
            {
                return Ok(await _matchService.GetCurrentMatchInfoAsync());
            }
            catch (ActiveMatchNotFoundException)
            {
                return NotFound("There is no active match at the moment");
            }
        }
    }
}