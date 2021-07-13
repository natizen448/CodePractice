using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] Animator anim;
    private bool dash;
    

     void Start()
     {
        
     }
    void Update()
    {   
        PlayerMove pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        dash = pm.isDash;
        Dasheffect();
        
    }

    void Dasheffect()
    {
        anim.SetBool("isdash", dash);

    }


}
