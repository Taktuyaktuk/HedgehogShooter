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
        Score1 = PlayerPrefs.GetFloat("BestScore").ToString();
        Score2 = PlayerPrefs.GetFloat("SecondScore").ToString();
        Score3 = PlayerPrefs.GetFloat("ThirdScore").ToString();
        TopScorer1.text = ("Your Best Score is : " + Score1);
        TopScorer2.text = ("Your Second Best Score is : " + Score2);
        TopScorer3.text = ("Your Third Best Score is : " + Score3);
    }



}
