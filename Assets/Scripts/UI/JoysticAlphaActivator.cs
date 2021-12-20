using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticAlphaActivator : MonoBehaviour
{
    public GameObject JoysticSprite;
    private void OnDisable()
    {
        JoysticSprite.SetActive(true);
        JoysticSprite.transform.position = this.gameObject.transform.position;
    }

    private void OnEnable()
    {
        JoysticSprite.SetActive(false);
    }
}
