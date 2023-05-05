using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour
{

    public GameManager gm;
    public float DMG = 15f, health = 100, armor;

    public void Hit(float DMG)
    {
        armor = Random.Range(0.2f, 0.5f);
        health -= DMG * armor;
        if (health <= 0)
        {
            gm.enemiesAlive--;
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
