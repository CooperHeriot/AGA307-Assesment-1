using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] EnemyTypes;

    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        for(int i =0; i < spawnPoints.Length; i++)
        {
            int rndEnemy = Random.Range(0, EnemyTypes.Length);
            GameObject enemy = Instantiate(EnemyTypes[rndEnemy], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(enemy);
        }
    }
}
