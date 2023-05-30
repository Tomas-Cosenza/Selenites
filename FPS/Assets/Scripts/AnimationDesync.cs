using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDesync : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("offset", Random.Range(0,1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
