using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtt : MonoBehaviour
{
    private Animator anim;
    private int setRangeCount = 1;
    [SerializeField] GameObject attRange;

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
            attRange.SetActive(true);
            if(setRangeCount > 0)
            {
               StartCoroutine(SetAttRange());
               setRangeCount--;
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
        attRange.SetActive(false);
        setRangeCount = 1;

    }
 
}
