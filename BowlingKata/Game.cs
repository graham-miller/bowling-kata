using System.Collections.Generic;

namespace BowlingKata
{
    public class Game
    {
        private const int TenPins = 10;
        private readonly List<int> _pins = new List<int>();

        public void Roll(int pins)
        {
            _pins.Add(pins);
        }

        public int Score()
        {
            var score = 0;

            for (var roll = 0; roll < _pins.Count; roll++)
            {
                score += Score(roll);

                if (IsSpareBonus(roll))
                    return score;
            }

            return score;
        }

        private int Score(int roll)
        {
            if (IsSpare(roll))
                return ScoreSpare(roll);

            if (IsStrike(roll))
            {
                return ScoreStrike(roll);
            }

            return _pins[roll];
        }

        private bool IsSpare(int roll)
        {
            return roll > 0 && _pins[roll] + _pins[roll - 1] == TenPins;
        }

        private int ScoreSpare(int roll)
        {
            return _pins[roll] + _pins[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return _pins[roll] == TenPins;
        }

        private int ScoreStrike(int roll)
        {
            return _pins[roll] + _pins[roll + 1] + _pins[roll + 2];
        }

        private bool IsSpareBonus(int roll)
        {
            return IsSpare(roll) && roll == _pins.Count - 2;
        }
    }
}
