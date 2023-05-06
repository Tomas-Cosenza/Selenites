using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonManAttack : MonoBehaviour
{
    public string[] attacks;
    public float firerate = 3;
    [SerializeField] private float radius = 5f, timer ;
    private GameObject player;
    [SerializeField] private Transform gravityClapSpawnPoint, gravitySlapSpawnPoint;
    [SerializeField] private GameObject gravityClap, gravitySlap;
    // Start is called before the first frame update
    void Start()
    {
        attacks = new string[] { "GravityClap", "GravitySlap" };
    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1 * Time.deltaTime;
        player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < radius && timer <= 0)
        {
            MoonAttack();
        }
    }

    public void GravityClap() 
    {

        GameObject.Instantiate(gravityClap, gravityClapSpawnPoint.position, Quaternion.identity);
    
    }

    public void GravitySlap()
    {

        GameObject.Instantiate(gravitySlap, gravitySlapSpawnPoint.position, Quaternion.identity);

    }

    private void MoonAttack() 
    {
        timer = firerate;
        string attackUsed = attacks[Random.Range(0, attacks.Length)];
        Invoke(attackUsed,0);
    }
}
