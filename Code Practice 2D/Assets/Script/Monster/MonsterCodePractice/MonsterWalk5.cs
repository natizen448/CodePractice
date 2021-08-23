using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk5 : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public int nextDir;
    
    void Awake()
    {
        Invoke("MonsterAI", 2);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(nextDir * 2, rb.velocity.y);
        PreventionFall();
    }
    
    void StopMove()
    {
        CancelInvoke();
    }
    void PreventionFall()
    {
        Vector2 frontvec = new Vector2(rb.position.x + nextDir * 0.3f, rb.velocity.y - 0.3f);//자기 앞으로 1만큼 떨어진위치
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down, 1, LayerMask.GetMask("Platform"));//플레이어 앞쪽으로 레이를 쏴서 Platform만 인식한다.
        //Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        anim.SetInteger("WalkSpeed", nextDir);//애니메이션실행
        if (rayhit.collider == null)//레이에 아무것도 안잡히면 방향전환후 함수재실행
        {
            Turn();
        }
    }

    void MonsterAI()
    {
        nextDir = Random.Range(-1, 2);
        //sr.flipX = (nextDir > 0) ? true : false;
        Invoke("MonsterAI", 2);
        if (nextDir != 0)
        {
            //스프라이트방향
            sr.flipX = nextDir == 1;
        }

    }
    void Turn()
    {
        nextDir *= -1;//방향전환
        sr.flipX = nextDir == 1;//스프라이트 방향전환
        CancelInvoke();
        Invoke("MonsterAI", 2);
        Debug.Log("절벽");
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopMove();
            nextDir = 0;
        }
    }

    
}
    