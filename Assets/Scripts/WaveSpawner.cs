using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs = new GameObject [3];
    public GameObject Enemies;
    private int _enemyPrefabs;
    private int _enemyCount;
    public int WaveNumber;
    public int EnemiesAmount;

    public float TimeBetweenEnemySpawn = 1f;
    public float TimeBetweenWaves = 5f;

    public Transform[] SpawnPoints = new Transform[4];

   private bool _spawningWave ;

    private void Awake()
    {
        WaveNumber = 0;
        EnemiesAmount = 2;
        if (_spawningWave == true)
        {
            StartCoroutine(SpawnEnemyWave(EnemiesAmount));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnEnemyWave(waveNumber));
    }

    // Update is called once per frame
    void Update()
    {
        _enemyCount = GameObject.Find("---------Enemies---------").GetComponentsInChildren<Transform>().Length;
        if(_enemyCount <=1)
        {
            StartCoroutine(SpawnEnemyWave(EnemiesAmount));
        }
       
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        Debug.Log("Current Wave" + WaveNumber);
        yield return new WaitForSeconds(TimeBetweenWaves); //We wait here to pause between wave spawning
        WaveNumber++;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int RandomEnemy = Random.Range(0, 3);
            var InstaniatedGameObject = Instantiate(EnemyPrefabs[RandomEnemy], SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, EnemyPrefabs[RandomEnemy].transform.rotation);
            InstaniatedGameObject.transform.parent = Enemies.transform;
            /*yield return new WaitForSeconds(timeBetweenEnemySpawn);*/ //We wait here to give a bit of time between each enemy spawn
        }
        if(EnemiesAmount < 8)
        {
            EnemiesAmount++;
        }
        _spawningWave = false;
        StopAllCoroutines();
    }
}
