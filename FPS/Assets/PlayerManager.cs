using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float health = 100f, damage = 20f;
    [SerializeField] private Slider slider;
    [SerializeField] private GameManager gm;
    public CharacterController controller;

    public void Hit(float damage, float knockback) 
    {
        transform.DOMove(transform.position - transform.forward * knockback, .5f);
        health -= damage;
        float actualHealth = Mathf.InverseLerp(0, 100, health);
        slider.DOValue(actualHealth, 1);
        if (health <= 0)
        {
            
            gm.EndGame();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();

    }

}
