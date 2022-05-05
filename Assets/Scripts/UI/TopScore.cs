using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TopScore : MonoBehaviour
{
    public TextMeshProUGUI TopScorer1;
    public TextMeshProUGUI TopScorer2;
    public TextMeshProUGUI TopScorer3;
    public TextMeshProUGUI TopSurvive;

    public string Score1;
    public string Score2;
    public string Score3;
    public string ScoreSurvive;

    

    private void Update()
    {
        ScoreDisplay();
    }

    public void ScoreDisplay()
    {
       
        Score1 = PlayerPrefs.GetFloat("BestScore").ToString("0.###");
        Score2 = PlayerPrefs.GetFloat("SecondScore").ToString("0.###");
        Score3 = PlayerPrefs.GetFloat("ThirdScore").ToString("0.###");
        ScoreSurvive = PlayerPrefs.GetInt("WaveRecord").ToString();
        string textToGameModes = "Complete this Game Mode to show your best Time";
        string textToSurvive = "Play Survive Mode to show your best Wave reached";

        if (PlayerPrefs.GetFloat("BestScore") == Mathf.Infinity)
        {
            TopScorer1.text = textToGameModes;
        }
        else
        {
            TopScorer1.text = ("Your Best Time is : " + Score1);
        }

        if (PlayerPrefs.GetFloat("SecondScore") == Mathf.Infinity)
        {
            TopScorer2.text = textToGameModes;
        }
        else
        {
            TopScorer2.text = ("Your Best Time is : " + Score2);
        }
        if (PlayerPrefs.GetFloat("ThirdScore") == Mathf.Infinity)
        {
            TopScorer3.text = textToGameModes;
        }
        else
        {
            TopScorer3.text = ("Your Best Time is : " + Score3);
        }

        if (PlayerPrefs.GetInt("WaveRecord") == 0)
        {
            TopSurvive.text = textToSurvive;
        }
        else
        {
            TopSurvive.text = ("Your best Wave reached is : " + ScoreSurvive);
        }
    }
}
