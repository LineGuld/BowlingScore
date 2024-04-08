using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingScore.Models;

namespace BowlingScore
{
    class Game
    {
        public IList<Frame> GameFrames { get; set; }

        public Game()
        {
            GameFrames = new List<Frame>();
        }
        public void playGame()
        {
            while (GameFrames.Count < 10)
            {
                Frame frame = new Frame();

                Console.WriteLine($"ROUND {GameFrames.Count + 1}, enter your rolls");

                for (int i = 1; i < 3; i++)
                {
                    Console.WriteLine($"Roll {i}");
                    Roll roll = Roll.RollFromUserInput();
                    frame.AddRoll(roll);
                    if (roll.GetKnockedPins() == 10)
                        break;
                }

                GameFrames.Add(frame);

                if (GameFrames.Count == 10 && (GameFrames[9].IsSpare() || GameFrames[9].IsStrike()))
                {
                    Console.WriteLine($"Bonus roll!");
                    Roll roll = new Roll();
                    roll.SetRollType(RollType.LastRoll);
                    roll = Roll.RollFromUserInput();
                    GameFrames[9].AddRoll(roll);
                }

            }
        }
        public void CalculateScore()
        {

        }

       
    }
}