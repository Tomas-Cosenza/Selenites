using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleporter : MonoBehaviour
{
    [SerializeField] private float radius=15, distance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private Vector3 offset;
    private EnemyHurt eh;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        eh = GetComponent<EnemyHurt>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 playerPos = new Vector3(player.position.x, 0, player.position.z);
        //Vector3 selfPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 playerPos = player.transform.position;

        distance = Vector3.Distance(transform.position, playerPos);
        if (distance > radius)
        {
            Teleport();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.forward) * radius;
        Gizmos.DrawRay(transform.position, direction);
    }
     private void Teleport()
    {
        //Vector3 position = spawnPoints[Random.Range(0, 8)].transform.position;
        //transform.position = position;
        //Debug.Log("teleported");
        eh.Hit(4444);
    }

/*private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Enemyspawner"))
        //{
        //    GameObject spawnPoint = es.enemySpawn[Random.Range(0, es.enemySpawn.Length)];
        //    transform.position = spawnPoint.transform.position + offset;
        //}
    }*/
}
