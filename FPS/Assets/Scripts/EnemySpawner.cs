using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private GameObject enemyPrefab;
    public int maxEnemies;
    public float spawnRate, spawnTime, startspawning = 30f;
    public GameObject[] enemySpawn;
    public int enemiesAlive;
    public int enemyIndex;
    public EnemySpawner enemySpawner;


    private void awake()
    {
      
        spawnTime = spawnRate;
        enemySpawner = GetComponent<EnemySpawner>();
    }
    // Update is called once per frame
    void Update()
    {

        if (startspawning > 0)
        {
            startspawning -= Time.deltaTime;
        }

        if (enemiesAlive < maxEnemies && startspawning <= 0)
        {

            SpawnEnemies();
            
        }

    }
    public void SpawnEnemies()
    {
        spawnTime -= Time.deltaTime*1;
        if (spawnTime <= 0) 
        { 
            GameObject spawnPoint = enemySpawn[Random.Range(0, enemySpawn.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position + spawnOffset, Quaternion.identity);
            enemySpawned.GetComponent<EnemyHurt>().es = enemySpawner;
            //enemySpawned.GetComponent<EnemyTeleporter>().es = enemySpawner;
            enemiesAlive++;
            spawnTime = spawnRate;
        }

    }

    //for (var x = enemiesAlive; x <= maxEnemies - 1; x++)
}
