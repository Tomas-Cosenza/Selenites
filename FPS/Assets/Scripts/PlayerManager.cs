using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float health = 100f, damage = 20f;
    [SerializeField] private Slider slider, sliderBG;
    [SerializeField] private GameManager gm;
    [SerializeField] private CanvasGroup hurtImage;
    public CharacterController controller;

    public void Hit(float damage, float knockback, Vector3 knockPos) 
    {
        hurtImage.DOFade(.5f, .3f).onComplete = () => hurtImage.DOFade(0, 1f);
        knockPos = new Vector3(knockPos.x,0,knockPos.z);
        Vector3 Self = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 Displacement = Vector3.Normalize((Self - knockPos))*knockback;
        transform.DOMove( transform.position + Displacement , .5f);
        health -= damage;
        float actualHealth = Mathf.InverseLerp(0, 100, health);
        slider.DOValue(actualHealth, 0.2f);
        sliderBG.DOValue(actualHealth, 0.5f);
        if (health <= 0)
        {
            hurtImage.DOFade(.5f, .5f).onComplete = ()=> Time.timeScale = 0;
            gm.EndGame();
            //Time.timeScale = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }
    



}
