using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    private Animator anim;
    private int SetRangeCount = 1;
    [SerializeField] GameObject AttRange;

    void Update()
    {
        PlayerInfo pl = GameObject.Find("Player").GetComponent<PlayerInfo>();
        anim = pl.anim;
        Att();
    }

    void Att()
    {   
        if(!anim.GetBool("isatt"))
        {
            if (Input.GetMouseButton(0)) 
            {   
            anim.SetBool("isatt", true);
            AttRange.SetActive(true);
            if(SetRangeCount > 0)
            {
               StartCoroutine(SetAttRange());
               SetRangeCount--;
            }
            
            }
            
        }
        
        else
        {  
           anim.SetBool("isatt", false);
           
        }
    }
    IEnumerator SetAttRange()
    {   

        yield return new WaitForSeconds(0.3f);
        AttRange.SetActive(false);
        SetRangeCount = 1;

    }
 
}
