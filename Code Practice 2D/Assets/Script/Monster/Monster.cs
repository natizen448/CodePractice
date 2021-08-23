using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Monster : MonoBehaviour
{   
   [SerializeField]private float monsterMoveSpeed;
    
    private int monsterMoveDirection;

    private bool findPlayer = false; 

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        NextDirection();
    }

    void MonsterMove()
    {
        anim.SetInteger("Moving", monsterMoveDirection);//애니메이터의 파라미터 세팅
        if (monsterMoveDirection != 0)
        {
            rb.velocity = new Vector2(monsterMoveSpeed * monsterMoveDirection, rb.velocity.y);//몬스터의 이동속도와 방향을 곱해서 이동
        }
      
    }

    void NextDirection()
    {
        monsterMoveDirection = UnityEngine.Random.Range(-1 ,2);//왼쪽,오른쪽,제자리등의 방향을 랜덤값으로 지정
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
    
    void PreventionFall()
    {
        Vector2 frontvec = new Vector2(rb.position.x + monsterMoveDirection * 0.3f, rb.velocity.y - 0.3f);//자기 앞으로 1만큼 떨어진위치
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down, 1, LayerMask.GetMask("Platform"));//플레이어 앞쪽으로 레이를 쏴서 Platform만 인식한다.
        Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        
        if (rayhit.collider == null)//레이에 아무것도 안잡히면 방향전환후 함수재실행
        {
            monsterMoveDirection *= -1;
            Flipx();
        }
    }
    void FixedUpdate()
    {
        MonsterMove();
        PreventionFall();
    }

    
}

