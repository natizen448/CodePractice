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
        Vector2 frontvec = new Vector2(rb.position.x + nextDir * 0.3f, rb.velocity.y - 0.3f);//�ڱ� ������ 1��ŭ ��������ġ
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down, 1, LayerMask.GetMask("Platform"));//�÷��̾� �������� ���̸� ���� Platform�� �ν��Ѵ�.
        //Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        anim.SetInteger("WalkSpeed", nextDir);//�ִϸ��̼ǽ���
        if (rayhit.collider == null)//���̿� �ƹ��͵� �������� ������ȯ�� �Լ������
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
            //��������Ʈ����
            sr.flipX = nextDir == 1;
        }

    }
    void Turn()
    {
        nextDir *= -1;//������ȯ
        sr.flipX = nextDir == 1;//��������Ʈ ������ȯ
        CancelInvoke();
        Invoke("MonsterAI", 2);
        Debug.Log("����");
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
    