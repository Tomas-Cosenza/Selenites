using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel, retrieveDataText, menuMusic, pausePanel;
    [SerializeField] private MouseLook ms;
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private WeaponManager wm;
    [SerializeField] private EnemySpawner[] es;
    [SerializeField] private Text roundNumber,roundsSurvived;
    //[SerializeField] private TextMesh retrieveDataText;
    [SerializeField] private Image crossHair, fadeIn;
    [SerializeField] private Image[] beacons;
    [SerializeField] private bool isGamePaused = false;
    private GameEnd ge;
    public int maxBeacons, beaconsClaimed;

    private void Start()
    {
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        DOTween.Init();
        ge = GameObject.FindGameObjectWithTag("GameEnd").GetComponent<GameEnd>();
        fadeIn.DOFade(0, 3f).SetEase(Ease.InCubic).onComplete = () => ActivateControl();
        menuMusic = GameObject.FindGameObjectWithTag("GameMusic");
        Destroy(menuMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void EndGame()
    {
         
        Cursor.lockState= CursorLockMode.None;
        endGamePanel.SetActive(true);
        crossHair.enabled = false;

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1;
    }

    public void BeaconCounter()
    {
        beacons[beaconsClaimed].DOFade(255, 1f);
        beaconsClaimed++;
        if(beaconsClaimed >= maxBeacons)
        {
            retrieveDataText.SetActive(true);
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

    private void ActivateControl()
    {
        ms.enabled = true;
        //pm.enabled = true;
        wm.enabled = true;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void Resume()
    {

        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

}
