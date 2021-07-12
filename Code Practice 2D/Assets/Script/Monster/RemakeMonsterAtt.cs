using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeMonsterAtt : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private int monsterDamgage;

    private bool isInSight = false;
    private int AttCount = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (AttCount > 0)
            {
                StartCoroutine(Att());
            }
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInSight = true;
            Debug.Log("¡¢√À¡ﬂ");
        }
    }


    IEnumerator Att()
    {   RemakeMonsterWalk mw = GameObject.Find("Monster").GetComponent<RemakeMonsterWalk>();
        PlayerInfo pi = GameObject.Find("Player").GetComponent<PlayerInfo>();
        mw.cancelAtt = true;
        mw.StopAllCoroutines();
        pi.HP -= monsterDamgage;      
        anim.SetBool("isatt", true);
        AttCount--;
        Debug.Log(pi.HP);
        StartCoroutine(AttClose());
        yield return null;
    }
   
    IEnumerator AttClose()
    {
        RemakeMonsterWalk mw = GameObject.Find("Monster").GetComponent<RemakeMonsterWalk>();
        StartCoroutine(AttCool());
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("isatt", false);
        anim.SetBool("IsMove", false);
        mw.StartCoroutine(mw.MonsterMoveDirection());
        yield return new WaitForSeconds(2f);
        mw.cancelAtt = false;
       
        AttCount = 1;


    }
    IEnumerator AttCool()
    {
        yield return new WaitForSeconds(2f);
        
    }
}
