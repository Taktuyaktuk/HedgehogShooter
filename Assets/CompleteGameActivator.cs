using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameActivator : MonoBehaviour
{
   public GameObject GameCompleteUi;
    public GameComplete GameEnded;

    private void Awake()
    {
        if (GameEnded == null)
        {
            GameEnded = GameObject.Find("GameComplete").GetComponent<GameComplete>();
        }
        if(GameCompleteUi == null)
        {
            GameCompleteUi = GameObject.Find("GameCompleteMenuUI");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            GameCompleteUi.SetActive(true);
            GameEnded.GameCompleted();
        }
    }
}
