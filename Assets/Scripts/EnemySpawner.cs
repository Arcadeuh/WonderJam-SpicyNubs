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









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
