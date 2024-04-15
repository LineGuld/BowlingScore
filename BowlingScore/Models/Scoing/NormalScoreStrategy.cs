using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models.Scoing
{
    internal class NormalScoreStrategy : IScoreStrategy
    {

        public int CalcuateScore(Frame frame, IList<Frame> frames, int index)
        {
            int score = 0;
            foreach (Roll roll in frame.Rolls) {
                score += roll.GetKnockedPins();
            }

            return score;
        }
    }
}
