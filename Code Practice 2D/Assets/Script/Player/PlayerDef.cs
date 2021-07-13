using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDef : MonoBehaviour
{
    
    private Animator anim;
    void Start()
    {   
        
    }
    
    void Update()
    {
        PlayerInfo pl = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        anim = pl.anim;
        Def();
        DefenseSpeed();
    }

    void DefenseSpeed()
    {
        PlayerInfo pl = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        if (Input.GetMouseButton(1))
        {
            pl.speed = 1f;
        }
        else
        {
            pl.speed = 3.5f;
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
