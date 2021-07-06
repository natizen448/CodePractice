using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtt : MonoBehaviour
{   
    public int Attcount = 1;
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
        Debug.Log("АјАн!");   
        mw.anim.SetBool("isatt", true);
        StartCoroutine(AttClose());
        StartCoroutine(AttCool());
        pl.HP -= 10;
        yield return null;
    }
    IEnumerator AttCool()
    {   
        yield return new WaitForSeconds(2f);
        Attcount = 1;
    }
    IEnumerator AttClose()
    {   
        yield return new WaitForSeconds(0.9f);
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        mw.anim.SetBool("isatt", false);
        mw.isFindPlayer = true;
        mw.cantFindPlayer = true;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
           MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        if (collision.CompareTag("Player") && Attcount == 1)
        {   
            mw.isFindPlayer = true;
            isFindPlayer = true;
            Attcount -= 1;
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        if (collision.CompareTag("Player") && Attcount == 1)
        {
            mw.isFindPlayer = true;
            isFindPlayer = true;
            Attcount -= 1;
        }
    }
    
}
