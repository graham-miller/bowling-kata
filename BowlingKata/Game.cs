using System.Collections.Generic;

namespace BowlingKata
{
    public class Game
    {
        private const int TenPins = 10;
        private readonly List<int> _rolls = new List<int>();

        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score()
        {
            var score = 0;

            for (var roll = 0; roll < _rolls.Count; roll++)
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
                return ScoreStrike(roll);

            return _rolls[roll];
        }

        private bool IsSpare(int roll)
        {
            return !IsFirst(roll) && _rolls[roll] + _rolls[roll - 1] == TenPins;
        }

        private static bool IsFirst(int roll)
        {
            return roll == 0;
        }

        private int ScoreSpare(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return _rolls[roll] == TenPins;
        }

        private int ScoreStrike(int roll)
        {
            return _rolls[roll] + _rolls[roll + 1] + _rolls[roll + 2];
        }

        private bool IsSpareBonus(int roll)
        {
            return IsSpare(roll) && roll == _rolls.Count - 2;
        }
    }
}
