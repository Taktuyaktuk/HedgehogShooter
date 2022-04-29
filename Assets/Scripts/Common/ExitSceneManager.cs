using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSceneManager : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
