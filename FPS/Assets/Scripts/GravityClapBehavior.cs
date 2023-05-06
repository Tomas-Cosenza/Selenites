using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClapBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystemForceField psf;
    [SerializeField]private GameObject Sphere;
    [SerializeField] private float lifeTime = 10;
    private GameObject player;
    private PlayerManager pm;
    private Collider aoe; 
    [SerializeField] private float DMG, pull,timer, knockDuration, pulseRate;
    [SerializeField] private bool knock;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
        aoe = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        lifeTime -= 1 * Time.deltaTime;
        timer -= 1 * Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        if (timer <= 0)
        {
            psf.enabled = true;
            aoe.enabled = true;
            Sphere.SetActive(true);
            Invoke("DeactivateAoE", .5f);
            timer = pulseRate;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pulse();
        }
    }
    private void DeactivateAoE()
    {

        psf.enabled = false;
        aoe.enabled = false;
        Sphere.SetActive(false);
    }
    private void Pulse()
    {
        pm.Hit(DMG, knock, -pull, knockDuration, transform.position);
    }
}
