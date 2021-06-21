using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] Animator anim;
    private bool Dash;

    void Update()
    {   
        PlayerMove pm = GameObject.Find("Player").GetComponent<PlayerMove>();
        Dash = pm.isDash;
        anim.SetBool("isdash", Dash);
    }
}
