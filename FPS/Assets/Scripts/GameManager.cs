using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive;
    [SerializeField] private int round;

    [SerializeField] private GameObject[] enemySpawn;

    [SerializeField] private GameObject enemyPrefab, endGamePanel;

    [SerializeField] private Text roundNumber,roundsSurvived;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive <= 0)
        {
            round++;
            NextWave(round);
            roundNumber.text="round:" + round.ToString();

        }

    }

    public void NextWave(int round)
    {
        for(var x = 0; x <= round;x++)
        {
            GameObject spawnPoint = enemySpawn[Random.Range(0, enemySpawn.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyMove>().gm = GetComponent<GameManager>();
            enemiesAlive++;

        }
    }

    public void EndGame()
    {
         
        Cursor.lockState= CursorLockMode.None;
        endGamePanel.SetActive(true);
        roundsSurvived.text = round.ToString();

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1;
    }

}
