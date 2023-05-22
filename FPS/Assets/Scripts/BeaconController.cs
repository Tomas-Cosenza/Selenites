using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeaconController : MonoBehaviour
{

    [SerializeField] private float beacontimer, timeToWait;

    [SerializeField] private Collider crashzone;

    [SerializeField] private Collider chargezone;

    [SerializeField] private GameObject beaconray, shipScreen, Chargezonelimits;
    [SerializeField] private GameManager gm;
    [SerializeField] private Slider slider;
    [SerializeField] private Light[] lights;


    private Transform player;
    // Start is called before the first frame update
    void Start()
    {

        Chargezonelimits.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        chargezone.enabled = false;
        beacontimer = timeToWait;
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
            Chargezonelimits.SetActive(true);
            lights[0].intensity = 1;
            lights[1].intensity = 1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //float progressBar;
            //progressBar = Mathf.InverseLerp(0, timeToWait, beacontimer);
            slider.value = beacontimer;
            Debug.Log(beacontimer);

            if (beacontimer <= 0)
            {
                gm.BeaconCounter();
                gm.UpDifficulty();
                shipScreen.SetActive(false);
                beaconray.SetActive(false);
                chargezone.enabled = false;
                crashzone.enabled = false;
                Chargezonelimits.SetActive(false);
                lights[0].intensity = 0;
                lights[1].intensity = 0;

            }
            else
            {

                slider.value = beacontimer;
                Debug.Log(beacontimer);
                beacontimer -= 1 * Time.deltaTime;

                shipScreen.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            beacontimer = timeToWait;
            chargezone.enabled = false;
            crashzone.enabled = true;
            Chargezonelimits.SetActive(false);
            shipScreen.SetActive(false);
            lights[0].intensity = 0;
            lights[1].intensity = 0;

        }
    }
}
