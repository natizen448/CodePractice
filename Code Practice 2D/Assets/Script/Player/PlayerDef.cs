using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDef : MonoBehaviour
{
    PlayerInfo pi;
    private Animator anim;
    void Start()
    {   
        pi = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
    }
    
    void Update()
    {
        
        anim = pi.anim;
        Def();
        DefenseSpeed();
    }

    void DefenseSpeed()
    {
        if (Input.GetMouseButton(1))
        {
            pi.speed = 1f;
        }
        else
        {
            pi.speed = 3.5f;
        }
    }


    void Def()
    {
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("isblock", true);
        }
        else
        {
            anim.SetBool("isblock", false);
        }
    }
}
