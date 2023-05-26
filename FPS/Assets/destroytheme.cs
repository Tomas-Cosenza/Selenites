using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroytheme : MonoBehaviour
{
    private PlayerManager pm;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.alive == false)
        {
            Destroy(gameObject);
        }
    }
}
