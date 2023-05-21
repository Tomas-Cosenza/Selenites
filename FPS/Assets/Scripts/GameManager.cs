using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private EnemySpawner[] es;
    [SerializeField] private Text roundNumber,roundsSurvived;
    private GameEnd ge;
    public int maxBeacons, beaconsClaimed;

    private void Start()
    {
        ge = GameObject.FindGameObjectWithTag("GameEnd").GetComponent<GameEnd>();
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

    public void BeaconCounter()
    {
        beaconsClaimed++;
        if(beaconsClaimed >= maxBeacons)
        {
            Win();
        }
    }

    public void UpDifficulty()
    {
        es[0].maxEnemies += 4;
        es[1].maxEnemies += 1;
        es[2].maxEnemies += 1;
    }

    public void Win()
    {
        Debug.Log("you won buddy");
        ge.EndGame();
    }

}
