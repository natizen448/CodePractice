using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtt : MonoBehaviour
{   
    public int attCount = 1;
    public bool isFindPlayer = false;
    PlayerInfo pl;
    MonsterWalk mw;

    private void Start()
    {
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        mw = GameObject.FindWithTag("Monster").GetComponent<MonsterWalk>();
    }
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
        mw.anim.SetBool("isatt", false);
        
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(CantFindPlayer());
        }
    }
    IEnumerator CantFindPlayer()    
    {
        yield return new WaitForSeconds(1f);
        mw.isMove = true;
        mw.startMove = true;
        Debug.Log("공격범위 벗어남");
    }
}
