using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI Coins;

    private void Update()
    {
        string coinsAmount = ("$ = " + PlayerPrefs.GetInt("Coins").ToString());
        Coins.text = coinsAmount;
    }
}
