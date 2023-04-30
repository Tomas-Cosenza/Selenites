using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;
    [SerializeField] private float range, DMG;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isFiring"))
        {
            anim.SetBool("isFiring", false);
        }
        if(Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        anim.SetBool("isFiring", true);

        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, transform.forward, out hit, range))
        {
            //Debug.Log("hit");
            EnemyMove enemyMove = hit.transform.GetComponent<EnemyMove>();

            if (enemyMove != null)
            {
                enemyMove.Hit(DMG);
            }
        }
    }
}
