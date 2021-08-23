using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : MonoBehaviour
{   
    [SerializeField]private float monsterMoveSpeed;
    [SerializeField] private float monsterAtt;

    private int monsterMoveDirection;
    private int monsterAttCount = 1;

    private bool findPlayer = false;

    PlayerInfo pi;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pi = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        NextDirection();
    }

    void MonsterMove()
    {
        anim.SetInteger("Moving", monsterMoveDirection);//애니메이터의 파라미터 세팅
        if (monsterMoveDirection != 0)
        {
            rb.velocity = new Vector2(monsterMoveSpeed * monsterMoveDirection, rb.velocity.y);//몬스터의 이동속도와 방향을 곱해서 이동
        }
      
    }//몬스터의 이동

    void NextDirection()//몬스터의 다음 이동방향
    {
        monsterMoveDirection = Random.Range(-1 ,2);//왼쪽,오른쪽,제자리등의 방향을 랜덤값으로 지정
        if (!findPlayer)
        {
            Invoke("NextDirection", 2);//재귀함수로 2초마다 호출
            Flipx();
        }
        
    }

    void Flipx()//몬스터의 스프라이트렌더러의 Flipx로 스프라이트의 방향을 바꿔줌
    {
        
        if(monsterMoveDirection > 0)
        {
            sr.flipX = true;
        }
        else if (monsterMoveDirection < 0)
        {
            sr.flipX = false;
        }
    }
    
    void PreventionFall()//몬스터가 다른층으로 떨어지는것을 방지
    {
        Vector2 frontVec = new Vector2(rb.position.x + monsterMoveDirection * 0.3f, rb.velocity.y - 0.3f);//자기 앞으로 1만큼 떨어진위치
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));//플레이어 앞쪽으로 레이를 쏴서 Platform만 인식한다.
        //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        
        if (rayHit.collider == null)//레이에 아무것도 안잡히면 방향전환후 함수재실행
        {
            monsterMoveDirection *= -1;
            Flipx();
        }
    }

    void MonsterSight()//플레이어를 발견하는 코드
    {
        Vector2 fowardVec = new Vector2(rb.position.x, rb.velocity.y);
        RaycastHit2D monsterSight = Physics2D.Raycast(fowardVec, new Vector3(monsterMoveDirection * 2, 0, 0), 2, LayerMask.GetMask("Player"));
        Debug.DrawRay(fowardVec, new Vector3(monsterMoveDirection * 2, 0, 0), new Color(0, 1, 0));

        if (monsterSight.collider != null)
        {
            CancelInvoke("NextDirection");
            monsterMoveDirection = 0;
            if (monsterAttCount > 0)
            {
                MonsterAtt();
            }
        }
    }

    void MonsterAtt()//몬스터 공격
    {
        monsterAttCount--;
        pi.HP -= monsterAtt;
        anim.SetTrigger("Attack");
        StartCoroutine(MonsterAttCooldown());
    }

    void FixedUpdate()
    {
        if (monsterAttCount > 0)
        {
            MonsterSight();
        }

        MonsterMove();
        PreventionFall();
    }

    IEnumerator MonsterAttCooldown()//몬스터의 공격 쿨타임
    {
        yield return new WaitForSeconds(2f);
        monsterAttCount = 1;
        NextDirection();
    }
    
}

