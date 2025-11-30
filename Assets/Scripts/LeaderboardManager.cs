using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    [System.Serializable]
    public class ScoreEntry
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class HighScores
    {
        public List<ScoreEntry> entryList = new List<ScoreEntry>();
    }

    public static void SaveScore(string name, int score)
    {
        HighScores highScores = LoadScores();

        highScores.entryList.Add(new ScoreEntry { name = name, score = score });

        highScores.entryList = highScores.entryList.OrderByDescending(x => x.score).ToList();

        if (highScores.entryList.Count > 10)
        {
            highScores.entryList.RemoveRange(10, highScores.entryList.Count - 10);
        }

        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("LeaderboardTable", json);
        PlayerPrefs.Save();
    }
    public static HighScores LoadScores()
    {
        string json = PlayerPrefs.GetString("LeaderboardTable", "{}");
        HighScores highScores = JsonUtility.FromJson<HighScores>(json);

        if (highScores == null) 
            highScores = new HighScores();

        return highScores;
    }
}