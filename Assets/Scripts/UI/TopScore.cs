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

    public string Score1;
    public string Score2;
    public string Score3;

    

    private void Update()
    {
        MaxScore();
        ScoreDisplay();
    }

    public void MaxScore()
    {
        if (PlayerPrefs.GetFloat("BestScore") == 0)
        {
            PlayerPrefs.SetFloat("BestScore", Mathf.Infinity);
        }

        if (PlayerPrefs.GetFloat("SecondScore") == 0)
        {
            PlayerPrefs.SetFloat("SecondScore", Mathf.Infinity);
        }

        if (PlayerPrefs.GetFloat("ThirdScore") == 0)
        {
            PlayerPrefs.SetFloat("ThirdScore", Mathf.Infinity);
        }
    }

    public void ScoreDisplay()
    {
       
        Score1 = PlayerPrefs.GetFloat("BestScore").ToString();
        Score2 = PlayerPrefs.GetFloat("SecondScore").ToString();
        Score3 = PlayerPrefs.GetFloat("ThirdScore").ToString();

        if (PlayerPrefs.GetFloat("BestScore") == Mathf.Infinity)
        {
            TopScorer1.text = "Complete this Game Mode to show your best Time";
        }
        else
        {
            TopScorer1.text = ("Your Best Score is : " + Score1);
        }

        if (PlayerPrefs.GetFloat("SecondScore") == Mathf.Infinity)
        {
            TopScorer2.text = "Complete this Game Mode to show your best Time";
        }
        else
        {
            TopScorer2.text = ("Your Second Best Score is : " + Score2);
        }
        if (PlayerPrefs.GetFloat("ThirdScore") == Mathf.Infinity)
        {
            TopScorer3.text = "Complete this Game Mode to show your best Time";
        }
        else
        {
            TopScorer3.text = ("Your Third Best Score is : " + Score3);
        }
    }
}
