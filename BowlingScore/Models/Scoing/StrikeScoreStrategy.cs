using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models.Scoing
{
    internal class StrikeScoreStrategy : IScoreStrategy
    {
        public int CalcuateScore(Frame frame, IList<Frame> frames, int index)
        {
            int score = 10;

            if (frames.Count > index + 1)
            {
                score += frames[index + 1].CalculateScore();

               /* if (frames[index + 1].IsStrike() && index + 2 < frames.Count)
                {
                    score += frames[index + 2].Rolls[0].GetKnockedPins();
                }*/

            }

            return score;
        }
    }
}
