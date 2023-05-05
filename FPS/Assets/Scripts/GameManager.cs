using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive;
    [SerializeField] private int enemyCap;
    public int maxEnemies;

    [SerializeField] private GameObject[] enemySpawn;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private Text roundNumber,roundsSurvived;
    // Start is called before the first frame update
    void Start()
    {
    }

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
        for(var x = enemiesAlive; x <= maxEnemies-1;x++)
        {
            GameObject spawnPoint = enemySpawn[Random.Range(0, enemySpawn.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyHurt>().gm = GetComponent<GameManager>();
            enemiesAlive++;

        }
    }

    public void EndGame()
    {
         
        Cursor.lockState= CursorLockMode.None;
        endGamePanel.SetActive(true);

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1;
    }

}
