using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    [SerializeField] private float speed, DMG, knocback;
    [SerializeField] private PlayerManager pM;
    private GameObject player;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        pM = player.GetComponent<PlayerManager>();
    }


    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
            pM.Hit(DMG,knocback);

        }
    }




}
