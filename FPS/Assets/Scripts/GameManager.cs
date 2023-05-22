using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private MouseLook ms;
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private WeaponManager wm;
    [SerializeField] private EnemySpawner[] es;
    [SerializeField] private Text roundNumber,roundsSurvived;
    [SerializeField] private Image crossHair, fadeIn;
    private GameEnd ge;
    public int maxBeacons, beaconsClaimed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DOTween.Init();
        ge = GameObject.FindGameObjectWithTag("GameEnd").GetComponent<GameEnd>();
        fadeIn.DOFade(0, 3f).SetEase(Ease.InCubic).onComplete = () => ActivateControl();
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

    private void ActivateControl()
    {
        ms.enabled = true;
        pm.enabled = true;
        wm.enabled = true;
    }

}
