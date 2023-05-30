using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerClippingRespawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform lowerLimit, spawnPosition;

    private void Start()
    {
        DOTween.Init();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.y <= lowerLimit.position.y)
        {
            player.transform.DOMove(new Vector3(transform.position.x, spawnPosition.position.y, transform.position.z), .1f);
        }
    }
}
