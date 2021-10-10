using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] spawnPoints;
    GameObject currentPoint;
    int index;
    
    public GameObject[] enemies;
    public float minTimeBtwnSpawns;
    public float maxTimeBtwnSpawns;
    public bool canSpawn;
    public float spawnTime;
    public int enemiesInLevel;
    public bool spawnerDone;
    public GameObject spawnerDoneGameObject;

    void SpawnEnemy()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        float timeBtwnSpawns = Random.Range(minTimeBtwnSpawns, maxTimeBtwnSpawns);

        if (canSpawn)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], currentPoint.transform.position, Quaternion.identity);
            enemiesInLevel++;
        }

        Invoke("SpawnEnemy", timeBtwnSpawns);

        if (spawnerDone)
        {
            //done spawning
            spawnerDoneGameObject.SetActive(true);
        }
    }







    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
