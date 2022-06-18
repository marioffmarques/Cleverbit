using Cleverbit.CodingTask.Application.Game;
using Cleverbit.CodingTask.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Play the current match.
        /// </summary>
        /// <returns>Number generated.</returns>
        [HttpPost("play")]
        [Authorize]
        public async Task<IActionResult> PlayCurrentMatchAsync()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                return Ok(await _gameService.PlayAsync(new Guid(userId)));
            }
            catch (MatchAlreadyPlayedException)
            {
                return BadRequest("User already played the current game");
            }
        }
    }
}