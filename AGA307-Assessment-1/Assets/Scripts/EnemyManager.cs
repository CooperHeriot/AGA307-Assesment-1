using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Transform[] spawnPoints;
    public GameObject[] EnemyTypes;

    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnOneEnemy();
        }
    }

    public void SpawnEnemy()
    {
        for(int i =0; i < spawnPoints.Length; i++)
        {
            int rndEnemy = Random.Range(0, EnemyTypes.Length);
            GameObject enemy = Instantiate(EnemyTypes[rndEnemy], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(enemy);
            _UI.UpdateTargets(enemies.Count);
        }
    }

    public void SpawnOneEnemy()
    {
            int rndEnemy = Random.Range(0, EnemyTypes.Length);
            int rndSpawn = Random.Range(0, spawnPoints.Length);
            GameObject enemy = Instantiate(EnemyTypes[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
            enemies.Add(enemy);
        _UI.UpdateTargets(enemies.Count);
        enemy.GetComponent<Target>().EM = gameObject.GetComponent<EnemyManager>();
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        _UI.UpdateTargets(enemies.Count);
    }

    /*public void UpdateEnemyDifficulty(int _Difficulty)
    {
        foreach (Target in enemies)
        {

        }
    }*/
}
