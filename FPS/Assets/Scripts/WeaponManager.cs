using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject mainCam, testEmpty, arms;
    [SerializeField] private Camera cam;
    [SerializeField] private float range, fireRate, zoom, DMG, zoomedSensitivity, aimSpeed, aimAnimProgress;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem /*spread,*/ hitConfirm;
    [SerializeField] private GameObject cameraOffset, bullet;
    [SerializeField] private MouseLook ml;
    [SerializeField] private Transform aimPos, restPos, gunNozzle, bulletPos;
    private float sensitivity = 700, cameraOffsetX = 4.8f, unZoomedSensitivity, timer;
    private bool isAiming;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        sensitivity = ml.sensitivity;
        unZoomedSensitivity = ml.sensitivity;
    }

    // Update is called once per frame
    void Update()
    {

        ml.sensitivity = sensitivity;
        cameraOffset.transform.localRotation = Quaternion.Euler(new Vector3(cameraOffsetX, 0, 0));
        timer -= Time.deltaTime;
        if (isAiming)
        {
            aimAnimProgress += aimSpeed * Time.deltaTime;
        }
        else
        {
            aimAnimProgress -= aimSpeed * Time.deltaTime;
        }

        aimAnimProgress = Mathf.Clamp(aimAnimProgress, 0, 1);
        arms.transform.position = Vector3.Lerp(restPos.position, aimPos.position, aimAnimProgress);

        if (anim.GetBool("isFiring"))
        {
            anim.SetBool("isFiring", false);
        }
        if(Input.GetButtonDown("Fire1") && timer <= 0) 
        {
            Shoot();
        }
        if(Input.GetButtonDown("Fire2"))
        {
            Zoom();

        }
        if (Input.GetButtonUp("Fire2"))
        {

            UnZoom();
        }

        RaycastHit hit;
        Physics.Raycast(mainCam.transform.position, cameraOffset.transform.forward, out hit, range);
        testEmpty.transform.position = hit.point;
    }

    private void Shoot()
    {
        anim.SetBool("isFiring", true);
        timer = fireRate;
        /*spread.Play();*/;
        Vector3 camOff =  (cameraOffset.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position , cameraOffset.transform.forward, out hit, range))
        {

            EnemyHurt enemyHurt = hit.transform.GetComponent<EnemyHurt>();
            hitConfirm.transform.position = hit.point;
            hitConfirm.Play();

            if (enemyHurt != null)
            {
                enemyHurt.Hit(DMG);
                GameObject bulletInstance = Instantiate(bullet, gunNozzle.position, Quaternion.identity);
                bulletInstance.transform.DOMove(hit.point, .2f);
                Destroy(bulletInstance, 1.5f);
            }
            else
            {

                GameObject bulletInstance = Instantiate(bullet, gunNozzle.position, Quaternion.identity);
                bulletInstance.transform.DOMove(hit.point, .2f);
                Destroy(bulletInstance, 1.5f);
            }
        }
        else 
        {
            GameObject bulletInstance = Instantiate(bullet, gunNozzle.position, Quaternion.identity);
            bulletInstance.transform.DOMove(bulletPos.position, .2f);
            Destroy(bulletInstance, 1.5f);
        }
    }

    private void Zoom()
    {
        isAiming = true;
        anim.SetBool("isAiming", true);
        cam.DOFieldOfView(zoom, .5f);
        DOTween.To(() => sensitivity, x => sensitivity = x, zoomedSensitivity, .5f);
        DOTween.To(() => cameraOffsetX, x => cameraOffsetX = x, 2.92f, .5f);
    }
    private void UnZoom()
    {
        isAiming = false;
        anim.SetBool("isAiming", false);
        cam.DOFieldOfView(60, .5f);
        DOTween.To(() => sensitivity, x => sensitivity = x, unZoomedSensitivity, .5f);
        DOTween.To(() => cameraOffsetX, x => cameraOffsetX = x, 4.8f, .5f);
    }
}
