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
        anim.SetInteger("Moving", monsterMoveDirection);//�ִϸ������� �Ķ���� ����
        if (monsterMoveDirection != 0)
        {
            rb.velocity = new Vector2(monsterMoveSpeed * monsterMoveDirection, rb.velocity.y);//������ �̵��ӵ��� ������ ���ؼ� �̵�
        }
      
    }

    void NextDirection()
    {
        monsterMoveDirection = UnityEngine.Random.Range(-1 ,2);//����,������,���ڸ����� ������ ���������� ����
        if (!findPlayer)
        {
            Invoke("NextDirection", 2);//����Լ��� 2�ʸ��� ȣ��
            Flipx();
        }
        
    }

    void Flipx()//������ ��������Ʈ�������� Flipx�� ��������Ʈ�� ������ �ٲ���
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
        Vector2 frontvec = new Vector2(rb.position.x + monsterMoveDirection * 0.3f, rb.velocity.y - 0.3f);//�ڱ� ������ 1��ŭ ��������ġ
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down, 1, LayerMask.GetMask("Platform"));//�÷��̾� �������� ���̸� ���� Platform�� �ν��Ѵ�.
        Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        
        if (rayhit.collider == null)//���̿� �ƹ��͵� �������� ������ȯ�� �Լ������
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

