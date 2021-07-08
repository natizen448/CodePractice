using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeMonsterAtt : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private int MonsterDamgage;

    private int AttCount = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (AttCount > 0)
            {
                RemakeMonsterWalk mw = GameObject.Find("Monster").GetComponent<RemakeMonsterWalk>();
                mw.CancelAtt = true;
                AttCount--;
                
                StartCoroutine(Att());
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            RemakeMonsterWalk mw = GameObject.Find("Monster").GetComponent<RemakeMonsterWalk>();
            StopCoroutine(Att());
            anim.SetBool("isatt", false);
            AttCount = 1;
            mw.StartCoroutine(mw.MonsterMoveDirection());
            mw.CancelAtt = false;
        }
    }

    IEnumerator Att()
    {   PlayerInfo pi = GameObject.Find("Player").GetComponent<PlayerInfo>();
       
        yield return new WaitForSeconds(1f);
        anim.SetBool("isatt", true);
        pi.HP -= MonsterDamgage;
        StartCoroutine(AttClose());
    }
    IEnumerator AttClose()
    {
        StartCoroutine(AttCool());
        yield return new WaitForSeconds(0.9f);
        anim.SetBool("isatt", false);
        
    }
    IEnumerator AttCool()
    {
        yield return new WaitForSeconds(2f);
        AttCount++;
    }
}
