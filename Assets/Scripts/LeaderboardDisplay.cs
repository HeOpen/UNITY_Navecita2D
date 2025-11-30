using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq; 

public class LeaderboardDisplay : MonoBehaviour
{
    // Assign the TextMeshPro field that will show the list
    public TMP_Text highScoresText; 

    // This method runs every time the panel is activated/opened
    void OnEnable() 
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        // 1. Get the data from the static manager
        LeaderboardManager.HighScores data = LeaderboardManager.LoadScores();

        // 2. Prepare the text output
        string output = "";

        // 3. Loop through the list and format each entry
        for (int i = 0; i < data.entryList.Count; i++)
        {
            LeaderboardManager.ScoreEntry entry = data.entryList[i];
            
            // Format: "1. [Name] - [Score]\n"
            output += (i + 1) + ". " + entry.name + " - " + entry.score + "points\n";
        }
        
        // 4. Update the TextMeshPro field
        highScoresText.text = output;

        // If the list is empty, show a message
        if (data.entryList.Count == 0)
        {
            highScoresText.text = "No scores recorded yet. Play a game!";
        }
    }
}