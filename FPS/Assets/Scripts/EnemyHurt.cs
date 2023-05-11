using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{

    [SerializeField] private float health = 100, armor;
    [SerializeField] private Animator anim;
    [HideInInspector] public EnemySpawner es;
    [SerializeField]private bool alive = true;
    private EnemyMove em;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        em = GetComponent<EnemyMove>();
    }

    public void Hit(float DMG)
    {
        armor = Random.Range(0.2f, 0.5f);
        health -= DMG * armor;
        if (health <= 0 && alive == true)
        {
            alive = false;
            es.enemiesAlive--;
            //Destroy(gameObject);
            if (em != null)
            {
                em.alive = false;
            }
            
            if (anim != null)
            {
                anim.SetBool("dead", true);
                Destroy(gameObject, 3);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

}
