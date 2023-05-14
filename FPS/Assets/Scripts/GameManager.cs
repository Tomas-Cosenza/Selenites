using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
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

    public void Win()
    {
        Debug.Log("you won buddy");
        ge.EndGame();
    }

}
