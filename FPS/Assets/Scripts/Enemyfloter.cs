using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemyfloter : MonoBehaviour
{
    [SerializeField] private float speed, radius, height, lift,peerspeed;
    private Transform player;
    [SerializeField] private BoxCollider checkpeer ;
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
       
            rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Force);
        }

        

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Vector3 directionPeer = Vector3.Normalize(transform.position - other.transform.position);
            rb.AddForce(directionPeer * peerspeed * Time.deltaTime, ForceMode.Force);
        }
    }



}


