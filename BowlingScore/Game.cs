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
            while (GameFrames.Count <= 10)
            {
                Frame frame = new Frame();
                Roll roll = new Roll();

                Console.WriteLine($"ROUND {GameFrames.Count + 1}, enter your rolls");

                for (int i = 1; i < 3; i++)
                {
                    Console.WriteLine($"Roll {i}");
                    roll = _getUserInputRoll();
                    frame.AddRoll(roll);
                    if (roll.GetKnockedPins() == 10)
                        break;
                }

                GameFrames.Add(frame);

                if (GameFrames.Count == 10 && (GameFrames[9].IsSpare() || GameFrames[9].IsStrike()))
                {
                    Console.WriteLine($"Bonus roll!");
                    roll.SetRollType(RollType.LastRoll);
                    roll = _getUserInputRoll();
                    GameFrames[9].AddRoll(roll);
                }

            }
        }
        public void CalculateScore()
        {

        }

        private bool _canParseInput(string value)
        {
            if (Int32.TryParse(value, out int numValue))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Int32.TryParse could not parse '{value}' to an int.");
                return false;
            }
        }
        private Roll _getUserInputRoll()
        {
            while (true)
            {
                try
                {
                    string value = Console.ReadLine();
                    if (_canParseInput(value))
                    {
                        Roll roll = new Roll();

                        roll.SetKnockedPins(Int32.Parse(value));
                        return roll;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a numeric value");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid value, please enter at number between 0 and 10");
                }
            }
        }
    }
}