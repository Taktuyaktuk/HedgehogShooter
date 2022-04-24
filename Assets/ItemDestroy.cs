using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy;

    private void Awake()
    {
        Destroy(this.gameObject, _timeToDestroy);
    }
}
