using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingScore.Util;

namespace BowlingScore.Models
{
    public class Frame
    {
        public IList<Roll> Rolls;

        public Frame()
        {
            Rolls = new List<Roll>();
        }

        //Used for testing
        public Frame(int roll1, int roll2)
        {
            Rolls = new List<Roll>();
            Roll firstRoll = new Roll();
            firstRoll.SetKnockedPins(roll1);

            Roll seconddRoll = new Roll();
            seconddRoll.SetKnockedPins(roll2);

            Rolls.Add(firstRoll);
            Rolls.Add(seconddRoll);
        }

        public void AddRoll(Roll roll)
        {
            if (Rolls.Count < 2)
            {
                Rolls.Add(roll);
            }
            else if (Rolls.Count == 2)
            {
                if (roll.GetRollType() == RollType.Default)
                {
                    Console.Write("Frame is finished, no more rolls can be added to this frame");
                }
                else if (roll.GetRollType() == RollType.LastRoll)
                {
                    Rolls.Add(roll);
                }
            }
        }

        public bool IsSpare()
        {
            if (!IsStrike() && Rolls[0].GetKnockedPins() + Rolls[1].GetKnockedPins() == 10)
            { return true; }

            return false;
        }

        public bool IsStrike()
        {
            if (Rolls[0].GetKnockedPins() == 10 && Rolls[1].GetKnockedPins() == 0)
            { return true; }

            return false;
        }
    }
}
