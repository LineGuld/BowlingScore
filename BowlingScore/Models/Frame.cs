using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models
{
    class Frame
    {
        public IList<Roll> Rolls;

        public Frame()
        {
            Rolls = new List<Roll>();
        }

        public void AddRoll(Roll roll)
        {
            if (Rolls.Count < 2)
            {
                Rolls.Add(roll);
            }
            else if (Rolls.Count == 2) {
                if (roll.GetRollType() == RollType.Default)
                {
                    Console.Write("Frame is finished, no more rolls can be added to this frame");
                }
                else if(roll.GetRollType() == RollType.LastRoll)
                {
                    Rolls.Add (roll);
                }
            }
        }

        public bool IsSpare()
        {
            return false;
            //TODO
        }

        public bool IsStrike()
        {
            return false;
            //TODO
        }
    }
}
