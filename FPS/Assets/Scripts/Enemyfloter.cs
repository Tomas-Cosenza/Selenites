using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfloter : MonoBehaviour
{
    [SerializeField] private float speed, radius, height, lift;
    private Transform player;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {

        // Find the player object based on its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        // Check if the player is within the radius
        float distance = Vector3.Distance(transform.position, player.position);
        if (transform.position.y <= height) 
        {
            rb.AddForce(new Vector3(0, 1, 0) * lift*Time.deltaTime, ForceMode.VelocityChange);
        }
        
        
        
        if (distance > radius)
        {
            // Move towards the player
       
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Force);
            //transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        /*if(transform.position.y <= 12)
        {
            transform.Translate(transform.position+Vector3.up*speed);
        }*/
    }
    //Vector3 MoveDir = Vector3.Normalize(transform.position - player.position) * -speed * Time.deltaTime;
}