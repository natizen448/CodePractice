using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeMonsterWalk : MonoBehaviour
{
    [SerializeField] private float monsterMoveSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject monsterSight;

    SpriteRenderer SR;
    Rigidbody2D Rb;
    private int nextDirection;
    private int dir;
    private int changeDirCount = 1;
    private bool direction;
    public bool isMonsterMoved = false;
    public bool cancelAtt = false;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MonsterMoveDirection());
    }
    void Update()
    {
        Walk();
        PreventionFall();

        if(dir > 0)
        {
            monsterSight.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(dir < 0)
        {
            monsterSight.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
      
    }

    void Walk()
    {
        if (!cancelAtt)
        {
            this.transform.position += new Vector3(monsterMoveSpeed * dir, 0, 0) * Time.deltaTime;
        }

        else
        {   
            StopCoroutine(MonsterMoveDirection());
        }

    }

    void MonsterDirection()
    {   direction = (nextDirection > 0) ? false : true;
        if (nextDirection == 0)
        {
            StopCoroutine(MoveAnim());
            dir = 0;
        }
        else
        {
            StartCoroutine(MoveAnim());
            if (nextDirection > 0)
            {
                dir = -1;
                monsterSight.transform.rotation = Quaternion.Euler(0, 0, 0);
                SR.flipX = direction;
            }
            else
            { 
                dir = 1;
                monsterSight.transform.rotation = Quaternion.Euler(0, -180, 0);
                SR.flipX = direction;
            }
           
        }
        
        StartCoroutine(MonsterMoveDirection());
    }

    void PreventionFall()
    {
        Vector2 frontvec = new Vector2(Rb.position.x+ (0.3f * dir), Rb.position.y);
        Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down,2, LayerMask.GetMask("Platform"));

        if (rayhit.collider == null)
        { 
            
            dir *= -1;
            StopAllCoroutines();
            StartCoroutine(CoolMoveDirection());
            SR.flipX = (dir > 0) ? true : false;

            
        }
    }

    public IEnumerator MonsterMoveDirection()
    {
        yield return new WaitForSeconds(2f);
        nextDirection = Random.Range(-2, 3);
        MonsterDirection();
    }

    IEnumerator CoolMoveDirection()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(MonsterMoveDirection());
    }
    IEnumerator MoveAnim()
    {
        anim.SetBool("IsMove", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("IsMove", false);
    }


}
