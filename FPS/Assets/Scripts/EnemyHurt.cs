using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{

    [SerializeField] private float health = 100, armor, explotionStrenght = 100, explotionRadius=50;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject deathModel;
    [SerializeField] private EnemyAtack ea;
    [HideInInspector] public EnemySpawner es;
    [SerializeField]private bool alive = true;
    private EnemyMove em;
    public AudioSource death;

    private void Awake()
    {
        //anim = GetComponent<Animator>();
        em = GetComponent<EnemyMove>();
        ea = GetComponent<EnemyAtack>();
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

            if (ea != null)
            {
                ea.alive = false;
            }

            if (deathModel != null)
            {
                GameObject corpse = Instantiate(deathModel, transform.position, transform.rotation);
                Rigidbody[] deathRB = corpse.GetComponentsInChildren<Rigidbody>();
                foreach (Rigidbody rb in deathRB)
                {
                    rb.AddExplosionForce(explotionStrenght, transform.position+transform.forward*1.5f, explotionRadius);
                    Debug.Log(rb.name);
                }
                Destroy(corpse, 5);
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
