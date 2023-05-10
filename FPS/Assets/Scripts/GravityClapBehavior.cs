using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GravityClapBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystemForceField psf;
    [SerializeField]private GameObject groundShatter;
    [SerializeField] private float lifeTime = 10, DMG, pull, timer, knockDuration, pulseRate;
    [SerializeField] private bool knock;
    [SerializeField] private Material areaMat;
    [SerializeField] private Light Light;
    private GameObject player;
    private PlayerManager pm;
    private Collider aoe;
    private float fade = .74f;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerManager>();
        aoe = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

        areaMat.SetFloat("_Smoke_fade", fade);
        
        lifeTime -= 1 * Time.deltaTime;
        timer -= 1 * Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        if (timer <= 0)
        {
            Light.DOIntensity(725, .5f);
            DOTween.To(() => fade, x => fade = x, 0f, 1f)/*.SetEase(Ease.OutQuint)*/;
            psf.enabled = true;
            aoe.enabled = true;
            GameObject destroyGroundShatter = Instantiate(groundShatter, transform.position - new Vector3(0, 3f, 0), Quaternion.identity);
            Destroy(destroyGroundShatter, 6);
            Invoke("DeactivateAoE", .5f);
            timer = pulseRate;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pulse();
        }
    }
    private void DeactivateAoE()
    {

        Light.DOIntensity(100, .5f);
        DOTween.To(() => fade, x => fade = x, .74f, 1f)/*.SetEase(Ease.OutQuint)*/;
        psf.enabled = false;
        aoe.enabled = false;
        //Sphere.SetActive(false);
    }
    private void Pulse()
    {
        pm.Hit(DMG, knock, -pull, knockDuration, transform.position);
    }
}
