using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.Models
{

    enum RollType
    {
        Default,
        LastRoll
    }
    class Roll
    {
        private RollType _rollType;
        private int _knockedPins;

        public RollType GetRollType() { return _rollType; }
        public void SetRollType(RollType rollType)
        {
            if (_rollType == null) { _rollType = RollType.Default; }
            _rollType = rollType;
        }

        public int GetKnockedPins() { return _knockedPins; }
        public void SetKnockedPins(int pins)
        {
            if (pins > 0 && pins <= 10)
            {
                _knockedPins = pins;
            }
            else if (pins > 10)
            {
                Console.Write("Knocked pins not set \n " +
                    "Number of knocked pins must be between 0 and 10 \n");
                throw new Exception();
            }
        }

    }
}
