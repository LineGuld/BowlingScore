using System.Runtime.Versioning;
using BowlingScore;
using BowlingScore.Models;
using BowlingScore.Util;

namespace BowlingScoreTest
{
    public class Tests
    {
       

        [Test]
        public void CorrectScoreAfterFirstFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4)
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(5));
        }

        [Test]
        public void CorrectScoreAfterSecondFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(14));
        }


        [Test]
        public void CorrectScoreAfterThirdFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(24));
        }

        [Test]
        public void CorrectScoreAfterFourthFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(39));
        }

        [Test]
        public void CorrectScoreAfterFifthFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(59));
        }

        [Test]
        public void CorrectScoreAfterSixthFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
                new Frame(0, 1),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(61));
        }

        [Test]
        public void CorrectScoreAfterSeventhFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
                new Frame(0, 1),
                new Frame(7, 3),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(71));
        }

        [Test]
        public void CorrectScoreAfterEighthFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
                new Frame(0, 1),
                new Frame(7, 3),
                new Frame(6, 4),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(87));
        }

        [Test]
        public void CorrectScoreAfterNinethFrame()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
                new Frame(0, 1),
                new Frame(7, 3),
                new Frame(6, 4),
                new Frame(10, 0),
            };

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(107));
        }

        [Test]
        public void CorrectOverallScore()
        {
            IList<Frame> GameFrames = new List<Frame>()
            {
                new Frame(1, 4),
                new Frame(4, 5),
                new Frame(6, 4),
                new Frame(5, 5),
                new Frame(10, 0),
                new Frame(0, 1),
                new Frame(7, 3),
                new Frame(6, 4),
                new Frame(10, 0),
                new Frame(2, 8)
            };

            Roll bonusRoll = new Roll();
            bonusRoll.SetRollType(RollType.LastRoll);
            bonusRoll.SetKnockedPins(6);
            GameFrames[9].AddRoll(bonusRoll);

            Game game = new Game();
            game.GameFrames = GameFrames;
            game.CalculateScore();

            Assert.That(game.GamesScore, Is.EqualTo(133));
        }
    }
}