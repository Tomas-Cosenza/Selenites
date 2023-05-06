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
    // Update is called once per frame
    void Update()
    {

        if (enemiesAlive < maxEnemies)
        {
            SpawnEnemies(maxEnemies);
        }

    }
    public void SpawnEnemies(int maxEnemies)
    {
        for (var x = enemiesAlive; x <= maxEnemies - 1; x++)
        {
            GameObject spawnPoint = enemySpawn[Random.Range(0, enemySpawn.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position+spawnOffset, Quaternion.identity);
            enemySpawned.GetComponent<EnemyHurt>().es = GetComponent<EnemySpawner>();
            enemiesAlive++;

        }
    }
}
