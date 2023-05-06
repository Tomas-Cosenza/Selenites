using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySlapBehavior : MonoBehaviour
{
    private GameObject player;
    private PlayerManager pm;
    [SerializeField] private ParticleSystem explotion;
    [SerializeField] private float lifeTime = 10,DMG,knockback, knockDuration;
    [SerializeField] private bool knock;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= 1 * Time.deltaTime;
        
        if (lifeTime <= 0)
        {
            Instantiate(explotion,transform.position,transform.rotation);
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            pm.Hit(DMG, knock, knockback, knockDuration, transform.position);
            Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
