using UnityEngine;
using TMPro;
using System.Collections;

public class CountDownTimer : MonoBehaviour
{
    public GameObject CountDownTimerUI;
    public TextMeshProUGUI Txt;
    private int _counter = 5;
    private int _enemyCount;
    private bool _countDownIsRunning;

    private void Awake()
    {
        _enemyCount = GameObject.Find("---------Enemies---------").GetComponentsInChildren<Transform>().Length;
        _countDownIsRunning = false;
    }

    private void Update()
    {
        _enemyCount = GameObject.Find("---------Enemies---------").GetComponentsInChildren<Transform>().Length;
        if(_enemyCount <2 && _countDownIsRunning == false)
        {
            StartCoroutine(CountDownDisplayer());
        }
    }

    IEnumerator CountDownDisplayer()
    {
        _countDownIsRunning = true;
        int Sec = 1;
        CountDownTimerUI.SetActive(true);
        Txt.text = _counter.ToString();
        yield return new WaitForSeconds(Sec);
        Txt.text = (_counter -= Sec).ToString();
        yield return new WaitForSeconds(Sec);
        Txt.text = (_counter -= Sec).ToString();
        yield return new WaitForSeconds(Sec);
        Txt.text = (_counter -= Sec).ToString();
        yield return new WaitForSeconds(Sec);
        Txt.text = (_counter -= Sec).ToString();
        yield return new WaitForSeconds(Sec);
        CountDownTimerUI.SetActive(false);
        _counter = 5;
        _countDownIsRunning = false;
        StopAllCoroutines();
    }

}
