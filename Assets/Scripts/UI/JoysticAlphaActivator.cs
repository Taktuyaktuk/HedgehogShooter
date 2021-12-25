using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticAlphaActivator : MonoBehaviour
{
    public GameObject JoysticSprite;
    private void OnDisable()
    {
        JoysticSprite.SetActive(true);
    }

    private void OnEnable()
    {
        JoysticSprite.SetActive(false);
    }
}
