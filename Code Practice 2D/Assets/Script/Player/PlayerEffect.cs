using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] Animator anim;
    private bool dash;
    PlayerMove pm;

    void Start()
     {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }
    void Update()
    {   
        
        dash = pm.isDash;
        Dasheffect();
        
    }

    void Dasheffect()
    {
        anim.SetBool("isdash", dash);

    }


}
