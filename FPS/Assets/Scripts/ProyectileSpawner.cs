using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ProyectilePrefab;
    [SerializeField] private float radius, firerate;
    [SerializeField] private Transform spawnPos;
    private Transform player;
    private float timer;

    public void SpawnProyectile()
    {
        Instantiate(ProyectilePrefab, spawnPos.position, spawnPos.rotation);

        timer = firerate;

    }

    void Start()
    {
        // Find the player object based on its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1 * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= radius   &&  timer <= 0 )
        {
            SpawnProyectile();
        }
    }
}
