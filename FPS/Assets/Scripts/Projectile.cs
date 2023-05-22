using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Rotator rotator;
    [SerializeField] private MeshRenderer starMeshRenderer, electricityMeshRenderer;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private ParticleSystem starTrail, starExplotion;
    [SerializeField] private float speed, DMG, knocback, knockDuration, lifetime = 5;
    [SerializeField] private bool knock;
    private GameObject player;
    private PlayerManager pM;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        pM = player.GetComponent<PlayerManager>();
        sphereCollider = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        lifetime -= 1* Time.deltaTime;
        if (lifetime <= 0)
        {
            starMeshRenderer.enabled = false;
            electricityMeshRenderer.enabled = false;
            sphereCollider.enabled = false;
            starTrail.Stop();
            starExplotion.Play();
            rotator.RotSpeed = 0;
            speed = 0;
            Invoke("DestroyProjectile", 1.2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereCollider.enabled = false;
            starMeshRenderer.enabled = false;
            electricityMeshRenderer.enabled = false;
            starTrail.Stop();
            starExplotion.Play();
            Destroy(gameObject,1);
            pM.Hit(DMG, knock, knocback, knockDuration, transform.position);

        }
        if (!other.CompareTag("Enemy") && !other.CompareTag("Enemyspawner") && !other.CompareTag("Beacon"))
        {
            starMeshRenderer.enabled = false;
            electricityMeshRenderer.enabled = false;
            sphereCollider.enabled = false;
            starTrail.Stop();
            starExplotion.Play();
            speed = 0;
            rotator.RotSpeed= 0;
            Invoke("DestroyProjectile", 1.2f);

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
    
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
