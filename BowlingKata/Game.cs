namespace BowlingKata
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            var score = 0;
            var rollIndex = 0;
            
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex))
                {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else
                {
                    score += PinsDroppedInFrame(rollIndex);
                    rollIndex += 2;
                }
            }

            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }

        private int StrikeBonus(in int rollIndex)
        {
            return _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private bool IsSpare(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex+1] == 10;
        }

        private int SpareBonus(int rollIndex)
        {
            return _rolls[rollIndex + 2];
        }

        private int PinsDroppedInFrame(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex+1];
        }
    }
}