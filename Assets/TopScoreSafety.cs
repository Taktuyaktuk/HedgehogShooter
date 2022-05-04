using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScoreSafety : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MaxScoreSafety();
    }

    public void MaxScoreSafety()
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
}
