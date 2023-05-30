using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsAnimationEvents : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }


    public void Landing()
    {
        anim.SetBool("landed", false);
        anim.SetBool("grounded", false);
    }
    public void Landed()
    {
        anim.SetBool("landed", true);
    }
}
