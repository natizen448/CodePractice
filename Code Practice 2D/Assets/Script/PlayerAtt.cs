using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        Att();
        Block();
    }

    void Att()
    {
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("isatt", true);
        }
        else
        {
            anim.SetBool("isatt", false);
        }
    }
  
    void Block()
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
