using System;

namespace Задание_8
{
    [Serializable]
    public class GameResult
    {
        public string PlayerName { get; set; }
        public int FinalScore { get; set; }
        public int SpinsCount { get; set; }
        public DateTime PlayDate { get; set; }
        public bool IsWin { get; set; }

        public GameResult() { }

        public GameResult(string playerName, int finalScore, int spinsCount, bool isWin)
        {
            PlayerName = playerName;
            FinalScore = finalScore;
            SpinsCount = spinsCount;
            PlayDate = DateTime.Now;
            IsWin = isWin;
        }
    }
}
