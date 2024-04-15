using BowlingScore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models.Scoing
{
    internal class SpareScoreStrategy : IScoreStrategy
    {
        public int CalcuateScore(Frame frame, IList<Frame> frames, int index)
        {
            int score = 10;

            if (frames.Count > index + 1)
            {
                score += frames[index + 1].Rolls[0].GetKnockedPins();
            }

            return score;
        }
    }
}
