using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    [SerializeField] private float speed, DMG, knocback, lifetime = 5;
    [SerializeField] private PlayerManager pM;
    [SerializeField] private Rotator rotator;
    [SerializeField] private MeshRenderer mr;
    [SerializeField] private SphereCollider sc;
    private GameObject player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        pM = player.GetComponent<PlayerManager>();
        sc = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifetime -= 1* Time.deltaTime;
        if (lifetime <= 0)
        {
            mr.enabled = false;
            sc.enabled = false;
            rotator.RotSpeed = 0;
            speed = 0;
            Invoke("DestroyProyectile", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            sc.enabled = false;
            mr.enabled = false;
            Destroy(gameObject);
            pM.Hit(DMG,knocback,transform.position);

        }
        if (!other.CompareTag("Enemy"))
        {
            mr.enabled = false;
            sc.enabled = false;
            speed = 0;
            rotator.RotSpeed= 0;
            Invoke("DestroyProyectile", 1f);

        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            mr.enabled = false;
            speed = 0;
            rotator.RotSpeed = 0;
            Invoke("DestroyProyectile", 1f);

        }
    }*/
    
    private void DestroyProyectile()
    {
        Destroy(gameObject);
    }

}
