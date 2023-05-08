using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSphere : MonoBehaviour
{
    //[SerializeField] private Collider killsphere;
    [SerializeField] private EnemyHurt hurt;
    // Start is called before the first frame update
    void Start()
    {

        hurt = GetComponent<EnemyHurt>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Enemyspawner"))
        {
            hurt.Hit(4444);
        }
    }
}
