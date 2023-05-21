using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float maxHealth, health = 100f, oxygenLevel;
    [SerializeField] private Slider slider, sliderBG, slider2, sliderBG2, oxygenGauge, oxygenGauge2;
    [SerializeField] private GameManager gm;
    [SerializeField] private CanvasGroup hurtImage, healImage;
    public CharacterController controller;



    public void Hit(float damage,bool knock , float knockback, float knockDuration, Vector3 knockPos)
    {
        health -= damage;
        hurtImage.DOFade(.5f, .3f).onComplete = () => hurtImage.DOFade(0, 1f);
        float actualHealth = Mathf.InverseLerp(0, 100, health);
        slider.DOValue(actualHealth, 0.2f);
        sliderBG.DOValue(actualHealth, 0.5f);
        slider2.DOValue(actualHealth, 0.2f);
        sliderBG2.DOValue(actualHealth, 0.5f);

        if (knock)
        {
            knockPos = new Vector3(knockPos.x, 0, knockPos.z);
            Vector3 Self = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 Displacement = Vector3.Normalize((Self - knockPos)) * knockback;
            transform.DOMove(transform.position + Displacement, knockDuration);
        }

        if (health <= 0)
        {
            hurtImage.DOFade(.5f, .5f).onComplete = ()=> Time.timeScale = 0;
            gm.EndGame();
            //Time.timeScale = 0;
        }
    }
    public void Heal(float heal) 
    {
        healImage.DOFade(.5f, .3f).onComplete = () => healImage.DOFade(0, 1f);
       
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
        float actualHealth = Mathf.InverseLerp(0, 100, health);
        slider.DOValue(actualHealth, 0.2f);
        sliderBG.DOValue(actualHealth, 0.5f);
        slider2.DOValue(actualHealth, 0.2f);
        sliderBG2.DOValue(actualHealth, 0.5f);
    }


    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
    }
    private void Update()
    {
        oxygenLevel -= Time.deltaTime;
        if(oxygenLevel <= 0)
        {
            Hit(444, false, 0, 0, Vector3.zero);
        }

        oxygenGauge.value = oxygenLevel;
        oxygenGauge2.value = oxygenLevel;
    }



}
