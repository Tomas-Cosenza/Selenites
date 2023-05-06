using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemySpawn;
    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int maxEnemies;
    public int enemiesAlive;
    public int enemyToSpawn;
    EnemySpawner[] enemySpawners;


    private void Start()
    {
        enemySpawners = GetComponents<EnemySpawner>();
    }
    // Update is called once per frame
    void Update()
    {

        if (enemiesAlive < maxEnemies)
        {
            
            SpawnEnemies(maxEnemies,enemyToSpawn);
        }

    }
    public void SpawnEnemies(int maxEnemies, int enemiesToSpawn)
    {
        for (var x = enemiesAlive; x <= maxEnemies - 1; x++)
        {
            GameObject spawnPoint = enemySpawn[Random.Range(0, enemySpawn.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position+spawnOffset, Quaternion.identity);
            enemySpawned.GetComponent<EnemyHurt>().es = enemySpawners[enemiesToSpawn];
            enemiesAlive++;

        }
    }
}
