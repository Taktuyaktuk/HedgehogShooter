using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common.ObjectPool;
using UnityEngine;

public class PlayersProjectileBehaviour : MonoBehaviour, IPooledObject
{
    public float Speed { get; set; }

    public void OnObjectSpawn()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
