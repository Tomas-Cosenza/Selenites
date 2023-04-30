using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfloter : MonoBehaviour
{
    [SerializeField] private float speed, radius;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object based on its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        // Check if the player is within the radius
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > radius)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}