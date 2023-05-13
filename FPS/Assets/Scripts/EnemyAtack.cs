using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private float DMG = 15f, knocback, knockDuration;
    [SerializeField] private bool knock;
    public bool alive;
    private GameObject player;
    //public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player && alive == true)
        {
            Invoke("Attack", .2f);
        }
    }

    private void Attack()
    {
        player.GetComponent<PlayerManager>().Hit(DMG, knock, knocback, knockDuration, transform.position);
    }
}
