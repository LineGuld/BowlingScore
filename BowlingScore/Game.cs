using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingScore.Models;
using BowlingScore.Util;

namespace BowlingScore
{
   public class Game
    {
        public IList<Frame> GameFrames { get; set; }
        public int GamesScore;
        private static int _framesInGame = 10;

        public Game()
        {
            GameFrames = new List<Frame>();
        }
        public void playGame()
        {
            while (GameFrames.Count < _framesInGame)
            {
                Frame frame = new Frame();

                Console.WriteLine($"ROUND {GameFrames.Count + 1}, enter your rolls");

                for (int i = 1; i < 3; i++)
                {
                    Console.WriteLine($"Roll {i}");
                    Roll roll = Roll.RollFromUserInput();
                    frame.AddRoll(roll);
                    if (roll.GetKnockedPins() == _framesInGame && frame.Rolls.Count == 1)
                    {
                        Roll roll2 = new Roll();
                        roll2.SetKnockedPins(0);
                        frame.AddRoll(roll2);
                        break;
                    }
                }

                GameFrames.Add(frame);

                if (GameFrames.Count == _framesInGame && (GameFrames[9].IsSpare() || GameFrames[9].IsStrike()))
                {
                    Console.WriteLine($"Bonus roll!");
                    Roll roll = new Roll();
                    roll.SetRollType(RollType.LastRoll);
                    roll = Roll.RollFromUserInput();
                    GameFrames[9].AddRoll(roll);
                }

                CalculateScore();
                Console.WriteLine($"CURRENT SCORE: {GamesScore}");
            }
        }
        public void CalculateScore()
        {
            GamesScore = 0;
            for (int i = 0; i < GameFrames.Count; i++)
            {
                Frame frame = GameFrames[i];

                GamesScore = GamesScore + frame.Rolls[0].GetKnockedPins() + frame.Rolls[1].GetKnockedPins();

                if (frame.IsSpare() && (GameFrames.Count > i + 1 || GameFrames.Count == _framesInGame) )
                {
                    if (i== _framesInGame-1 )
                    {
                        GamesScore = GamesScore + GameFrames[_framesInGame-1].Rolls[2].GetKnockedPins();
                    }
                    else
                    GamesScore = GamesScore + GameFrames[i + 1].Rolls[0].GetKnockedPins();
                }

                if (frame.IsStrike() && (GameFrames.Count > i + 1 || GameFrames.Count == _framesInGame))
                {
                    if (i == _framesInGame-1 )
                    {
                        GamesScore = GamesScore + GameFrames[_framesInGame-1].Rolls[2].GetKnockedPins();
                    }
                    else
                    GamesScore = GamesScore + GameFrames[i + 1].Rolls[0].GetKnockedPins() + GameFrames[i + 1].Rolls[1].GetKnockedPins();
                }
            }
        }
    }
}