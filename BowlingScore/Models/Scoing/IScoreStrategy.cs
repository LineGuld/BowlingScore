using BowlingScore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models.Scoing
{
    internal interface IScoreStrategy
    {
        public int CalcuateScore(Frame frame, IList<Frame> frames, int index);
    }
}
