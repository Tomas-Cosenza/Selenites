using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCam, testEmpty;
    [SerializeField] private float range, DMG;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem spread, hitConfirm;
    [SerializeField] private GameObject cameraOffset;

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

        RaycastHit hit;
        Physics.Raycast(mainCam.transform.position, cameraOffset.transform.forward, out hit, range);
        testEmpty.transform.position = hit.point;
    }

    private void Shoot()
    {
        anim.SetBool("isFiring", true);

        spread.Play();

        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position , cameraOffset.transform.forward, out hit, range))
        {
            //Debug.Log("hit");
            EnemyMove enemyMove = hit.transform.GetComponent<EnemyMove>();
            hitConfirm.transform.position = hit.point/*transform.position + new Vector3(0,1,0)*/;
            hitConfirm.Play();
            
            if (enemyMove != null)
            {
                enemyMove.Hit(DMG);
            }
        }
    }
}
