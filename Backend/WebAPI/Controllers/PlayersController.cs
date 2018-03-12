using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Player> _repoPlayer;
        private readonly IRepository<Game> _repoGame;
        private readonly IRepository<Log> _repoLog;
        private readonly IUnitOfWork _unitOfWork;

        public PlayersController(IMapper mapper, IRepository<Player> repoPlayer, IRepository<Game> repoGame, 
            IRepository<Log> repoLog, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repoPlayer = repoPlayer;
            _repoGame = repoGame;
            _repoLog = repoLog;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("leaderboard")]
        public async Task<IActionResult> GetLeaderboard()
        {
            _repoLog.Add(new Log() { Level = LogLevel.Information, Description = "Getting leaderboard" });

            var players = await _repoPlayer.GetEntitiesAsync();
            var playerResources = _mapper.Map<List<Player>, List<PlayerResource>>(players);

            foreach (var player in playerResources)
            {
                var gamesWon = await _repoGame.GetEntitiesByFilterAsync(g => g.WinnerId == player.Id);
                player.Wins = gamesWon.Count();
            }

            await _unitOfWork.CompleteAsync();
            return Ok(playerResources);
        }
    }
}
