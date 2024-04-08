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

        private static bool _canParseInput(string value)
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
        public static Roll RollFromUserInput()
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
