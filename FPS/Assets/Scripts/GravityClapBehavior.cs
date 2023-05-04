using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityClapBehavior : MonoBehaviour
{
    [SerializeField]private GameObject Sphere;
    [SerializeField] private float lifeTime = 10;
    private GameObject player;
    private PlayerManager pm;
    private Collider aoe;

    [SerializeField] private float DMG, knockback,timer,pulseRate;
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
        aoe.enabled = false;
        Sphere.SetActive(false);
    }
    private void Pulse()
    {
        pm.Hit(DMG, knockback, transform.position);
    }
}
