using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconFunctionality : MonoBehaviour
{

    [SerializeField] private float beacontimer = 90f;

    [SerializeField] private Collider crashzone;

    [SerializeField] private Collider chargezone;

    [SerializeField] private GameObject beaconray;
    [SerializeField] private GameManager gm;


    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chargezone.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            chargezone.enabled = true;
            crashzone.enabled = false;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            beacontimer -= 1 * Time.deltaTime;
            Debug.Log(beacontimer);

            if (beacontimer <= 0)
            {
                gm.BeaconCounter();
                chargezone.enabled = false;
                crashzone.enabled = false;
                // Faltaria buscar en el Gm la funcion que suma beacons y haga ++
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            beacontimer = 90;
            chargezone.enabled = false;
            crashzone.enabled = true;

        }
    }
}
