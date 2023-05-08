using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{

    [SerializeField] private float health = 100, armor;
    [HideInInspector] public EnemySpawner es;

    public void Hit(float DMG)
    {
        armor = Random.Range(0.2f, 0.5f);
        health -= DMG * armor;
        if (health <= 0)
        {
            es.enemiesAlive--;
            Destroy(gameObject);
        }

    }
}
