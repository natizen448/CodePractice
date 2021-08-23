using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtt2 : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private int monsterDamgage;

    private bool isInSight = false;
    private int AttCount = 1;

    MonsterWalk2 mw;
    PlayerInfo pi;

    private void Start()
    {
        mw = GameObject.FindWithTag("Monster").GetComponent<MonsterWalk2>();
        pi = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
    }
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
    {
        mw.dir = 0;
        mw.cancelAtt = true;
        mw.StopAllCoroutines();
        pi.HP -= (monsterDamgage - (monsterDamgage * (pi.def / 100)));     
        anim.SetBool("isatt", true);
        AttCount--;
        Debug.Log(pi.HP);
        StartCoroutine(AttClose());
        yield return null;
    }
   
    IEnumerator AttClose()
    {
        StartCoroutine(AttCool());
        yield return new WaitForSeconds(0.9f);
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
