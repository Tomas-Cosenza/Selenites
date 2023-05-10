using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollow : MonoBehaviour
{
    [SerializeField] private Transform player, edgeL, edgeR, edgeT, edgeB;
    [SerializeField] private GameObject spawnCenter;
    [SerializeField] private float H, V;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        H = player.position.x;
        H = Mathf.Clamp(H, edgeL.position.x, edgeR.position.x);
        V = player.position.z;
        V = Mathf.Clamp(V, edgeB.position.z, edgeT.position.z);

        spawnCenter.transform.position = new Vector3(H, transform.position.y,V);
    }
}
