using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    [SerializeField] private float speed, DMG, knocback;
    [SerializeField] private PlayerManager pM;
    [SerializeField] private Rotator rotator;
    private GameObject player;
    private float lifetime = 5;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        pM = player.GetComponent<PlayerManager>();
    }


    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifetime -= 1* Time.deltaTime;
        if (lifetime <= 0)
        {
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            mr.enabled = false;
            rotator.RotSpeed = 0;

            Invoke("DestroyProyectile", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
            pM.Hit(DMG,knocback,transform.position);

        }
        if (!other.CompareTag("Enemy"))
        {
            MeshRenderer mr= gameObject.GetComponent<MeshRenderer>();
            mr.enabled = false;
            speed = 0;
            rotator.RotSpeed= 0;
            Invoke("DestroyProyectile", 1f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    
    private void DestroyProyectile()
    {
        Destroy(gameObject);
    }

}
