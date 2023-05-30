using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private BoxCollider bc;
    private PlayerManager pm;
    [SerializeField] private Image fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        bc = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        pm.Heal(1000);

        fadeIn.DOFade(255, 3f).SetEase(Ease.InCubic).onComplete = () => SceneManager.LoadScene(3);
    }

    public void EndGame()
    {
        bc.isTrigger = true;
    }
}
