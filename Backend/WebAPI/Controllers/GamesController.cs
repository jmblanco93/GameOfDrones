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
    public class GamesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Player> _repoPlayer;
        private readonly IRepository<Game> _repoGame;
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IMapper mapper, IRepository<Player> repoPlayer, IRepository<Game> repoGame,
                IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repoPlayer = repoPlayer;
            _repoGame = repoGame;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> StartGame([FromBody]SaveGameResource saveGameResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (saveGameResource.Player1.Trim().ToUpper() == saveGameResource.Player2.Trim().ToUpper())
                return BadRequest("The players can't be the same");

            var player1 = await _repoPlayer.GetEntityByFilterAsync(p => p.Name == saveGameResource.Player1);

            if (player1 == null)
                player1 = new Player() { Name = saveGameResource.Player1 };

            var player2 = await _repoPlayer.GetEntityByFilterAsync(p => p.Name == saveGameResource.Player2);

            if (player2 == null)
                player2 = new Player() { Name = saveGameResource.Player2 };

            var game = new Game() { Player1 = player1, Player2 = player2 };

            _repoGame.Add(game);
            await _unitOfWork.CompleteAsync();

            game = await _repoGame.GetEntityByFilterAsync(g => g.Id == game.Id);

            var gameResource = _mapper.Map<Game, GameResource>(game);

            return Ok(gameResource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(Guid id)
        {
            var game = await _repoGame.GetEntityByFilterAsync(g => g.Id == id);

            if (game == null)
                return NotFound();

            var gameResource = _mapper.Map<Game, GameResource>(game);

            return Ok(gameResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _repoGame.GetEntitiesAsync();
            var gameResources = _mapper.Map<List<Game>, List<GameResource>>(games);

            return Ok(gameResources);
        }

        [HttpPost("{gameId}/rounds")]
        public async Task<IActionResult> PostRound(Guid GameId, [FromBody] RoundResource roundResource)
        {
            var game = await _repoGame.GetEntityByFilterAsync(g => g.Id == GameId);
            var round = _mapper.Map<RoundResource, Round>(roundResource);
            var result = ComputeRound(round.Player1Move, round.Player2Move);
            round.Result = result;
            game.Rounds.Add(round);

            var player1Wins = game.Rounds.Where(r => r.Result == RoundResult.WinsPlayer1).Count();
            if (player1Wins == 3)
                game.Winner = game.Player1;
            else
            {
                var player2Wins = game.Rounds.Where(r => r.Result == RoundResult.WinsPlayer2).Count();
                if (player2Wins == 3)
                    game.Winner = game.Player2;
            }

            game.LastUpdate = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();

            game = await _repoGame.GetEntityByFilterAsync(g => g.Id == game.Id);


            var gameResource = _mapper.Map<Game, GameResource>(game);
            return Ok(gameResource);
        }

        private RoundResult ComputeRound(Move Player1Move, Move Player2Move)
        {
            switch (Player1Move)
            {
                case Move.Paper:
                    if (Player2Move == Move.Paper)
                        return RoundResult.Tie;
                    else if (Player2Move == Move.Rock)
                        return RoundResult.WinsPlayer1;
                    else
                        return RoundResult.WinsPlayer2;
                case Move.Rock:
                    if (Player2Move == Move.Paper)
                        return RoundResult.WinsPlayer2;
                    else if (Player2Move == Move.Rock)
                        return RoundResult.Tie;
                    else
                        return RoundResult.WinsPlayer1;
                case Move.Scissors:
                    if (Player2Move == Move.Paper)
                        return RoundResult.WinsPlayer1;
                    else if (Player2Move == Move.Rock)
                        return RoundResult.WinsPlayer2;
                    else
                        return RoundResult.Tie;
                default:
                    return RoundResult.Tie;
            }
        }
    }
}