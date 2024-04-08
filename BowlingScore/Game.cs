﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingScore.Models;
using BowlingScore.Util;

namespace BowlingScore
{
    class Game
    {
        public IList<Frame> GameFrames { get; set; }
        public int GamesScore;

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
                    if (roll.GetKnockedPins() == 10 && frame.Rolls.Count == 1)
                    {
                        Roll roll2 = new Roll();
                        roll2.SetKnockedPins(0);
                        frame.AddRoll(roll2);
                        break;
                    }
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

                if (frame.IsSpare() && GameFrames.Count > i + 2)
                {

                    GamesScore = GamesScore + GameFrames[i + 1].Rolls[0].GetKnockedPins();

                }
                if (frame.IsStrike() && GameFrames.Count > i + 2)
                {

                    GamesScore = GamesScore + GameFrames[i + 1].Rolls[0].GetKnockedPins() + GameFrames[i + 1].Rolls[0].GetKnockedPins();

                }
                

            }
        }
    }
}