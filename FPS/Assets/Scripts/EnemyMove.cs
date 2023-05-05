using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{

    public GameObject player;
    public GameManager gm;
    //public Animator zombieanimator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        /*if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            zombieanimator.SetBool("isrunning", true);
        }
        else
        {
            zombieanimator.SetBool("isrunning", false);

        }*/

        
    }


   


}
