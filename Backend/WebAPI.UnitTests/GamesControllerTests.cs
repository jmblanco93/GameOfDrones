using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Controllers;

namespace WebAPI.UnitTests
{
    [TestFixture]
    public class GamesControllerTests
    {
        [Test]
        [TestCase(Move.Paper, Move.Paper, RoundResult.Tie)]
        [TestCase(Move.Paper, Move.Rock, RoundResult.WinsPlayer1)]
        [TestCase(Move.Paper, Move.Scissors, RoundResult.WinsPlayer2)]
        [TestCase(Move.Rock, Move.Paper, RoundResult.WinsPlayer2)]
        [TestCase(Move.Rock, Move.Rock, RoundResult.Tie)]
        [TestCase(Move.Rock, Move.Scissors, RoundResult.WinsPlayer1)]
        [TestCase(Move.Scissors, Move.Paper, RoundResult.WinsPlayer1)]
        [TestCase(Move.Scissors, Move.Rock, RoundResult.WinsPlayer2)]
        [TestCase(Move.Scissors, Move.Scissors, RoundResult.Tie)]
        public void ComputedRound_WhenCalled_ReturnTheRoundResult(Move Player1Move, Move Player2Move, RoundResult expectedResult)
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepoPlayer = new Mock<IRepository<Player>>();
            var mockRepoGame = new Mock<IRepository<Game>>();
            var mockRepoLog = new Mock<IRepository<Log>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();


            var controller = new GamesController(mockMapper.Object, mockRepoPlayer.Object, mockRepoGame.Object, mockUnitOfWork.Object, mockRepoLog.Object);

            var result = controller.ComputeRound(Player1Move, Player2Move);

            Assert.That(result, Is.EqualTo(expectedResult));

        }
    }

    
}
