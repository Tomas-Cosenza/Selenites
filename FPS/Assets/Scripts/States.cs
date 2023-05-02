using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    public enum CurrentState  { chasing , attacking, idle , death}

    public CurrentState currentState;

    private GameObject player;

    [SerializeField] private float eradius, estamina;

    // Start is called before the first frame update
    void Start()
    {
        

        player = GameObject.FindGameObjectWithTag("Player");
        
        SetupCurrentState();
    }

    private void SetupCurrentState()
    {
        switch(currentState)
        {
            case CurrentState.chasing:
                Debug.Log("Caca");
                break;
            
            case CurrentState.attacking:
                break;
            
            case CurrentState.idle:
                Debug.Log("Ventu");
                break;
            
            case CurrentState.death:
                break;

            default:
                break;
        }    
    
    
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > eradius)
        {
            currentState = CurrentState.chasing;
        }
        else 
        {
            currentState = CurrentState.idle;

        }

        SetupCurrentState();


    }
}
