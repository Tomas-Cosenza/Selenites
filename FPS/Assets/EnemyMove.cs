using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{

    public GameObject player;
    public GameManager gm;
    public Animator zombieanimator;
    public float DMG = 15f,knocback, healt = 100, armor;

    public void Hit(float DMG)
    {
        armor = Random.Range(0.2f, 0.5f);
        healt -= DMG * armor;
        if(healt<=0) 
        {
            gm.enemiesAlive--;
            Destroy(gameObject);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            zombieanimator.SetBool("isrunning", true);
        }
        else
        {
            zombieanimator.SetBool("isrunning", false);

        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(DMG, knocback);
        }
    }

   


}
