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
        anim.SetInteger("Moving", monsterMoveDirection);//�ִϸ������� �Ķ���� ����
        if (monsterMoveDirection != 0)
        {
            rb.velocity = new Vector2(monsterMoveSpeed * monsterMoveDirection, rb.velocity.y);//������ �̵��ӵ��� ������ ���ؼ� �̵�
        }
      
    }//������ �̵�

    void NextDirection()//������ ���� �̵�����
    {
        monsterMoveDirection = Random.Range(-1 ,2);//����,������,���ڸ����� ������ ���������� ����
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
    
    void PreventionFall()//���Ͱ� �ٸ������� �������°��� ����
    {
        Vector2 frontVec = new Vector2(rb.position.x + monsterMoveDirection * 0.3f, rb.velocity.y - 0.3f);//�ڱ� ������ 1��ŭ ��������ġ
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));//�÷��̾� �������� ���̸� ���� Platform�� �ν��Ѵ�.
        //Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        
        if (rayHit.collider == null)//���̿� �ƹ��͵� �������� ������ȯ�� �Լ������
        {
            monsterMoveDirection *= -1;
            Flipx();
        }
    }

    void MonsterSight()//�÷��̾ �߰��ϴ� �ڵ�
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

    void MonsterAtt()//���� ����
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

    IEnumerator MonsterAttCooldown()//������ ���� ��Ÿ��
    {
        yield return new WaitForSeconds(2f);
        monsterAttCount = 1;
        NextDirection();
    }
    
}

