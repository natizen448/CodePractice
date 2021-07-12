using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtt : MonoBehaviour
{   
    public int attCount = 1;
    public bool isFindPlayer = false;

    void Update()
    {
        if(isFindPlayer)
        {
            StartCoroutine(Att());
        }
    }

    IEnumerator Att()
    {   
        isFindPlayer = false;
        PlayerInfo pl = GameObject.Find("Player").GetComponent<PlayerInfo>();
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        Debug.Log("공격!");   
        mw.anim.SetBool("isatt", true);
        StartCoroutine(AttCool());
        StartCoroutine(AttClose());
        pl.HP -= 10;
        yield return null;
    }
    IEnumerator AttCool()
    {   
        yield return new WaitForSeconds(2f);
        attCount = 1;
    }
    IEnumerator AttClose()
    {   
        yield return new WaitForSeconds(0.5f);
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        mw.anim.SetBool("isatt", false);
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        if (collision.CompareTag("Player") && attCount == 1)
        {
            StopCoroutine(CantFindPlayer());
            mw.isMove = false;
            isFindPlayer = true;
            attCount -= 1;
        }

       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(CantFindPlayer());
            
        }
    }
    IEnumerator CantFindPlayer()    
    {
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        yield return new WaitForSeconds(1f);
        mw.isMove = true;
        mw.startMove = true;
        Debug.Log("공격범위 벗어남");
    }
}
