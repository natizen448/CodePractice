using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeMonsterWalk : MonoBehaviour
{
    [SerializeField] private float MonsterMoveSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject MonsterSight;

    SpriteRenderer SR;
    Rigidbody2D Rb;
    private int NextDirection;
    private int Dir;
    private int ChangeDirCount = 1;
    private bool Direction;
    public bool IsMonsterMoved = false;
    public bool CancelAtt = false;

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

        if(Dir > 0)
        {
            MonsterSight.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Dir < 0)
        {
            MonsterSight.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
      
    }

    void Walk()
    {
        if (!CancelAtt)
        {
            this.transform.position += new Vector3(MonsterMoveSpeed * Dir, 0, 0) * Time.deltaTime;
        }

        else
        {   
            StopCoroutine(MonsterMoveDirection());
        }

    }

    void MonsterDirection()
    {   Direction = (NextDirection > 0) ? false : true;
        if (NextDirection == 0)
        {
            Dir = 0;
                
        }
        else
        {
            StartCoroutine(MoveAnim());
            if (NextDirection > 0)
            {
                Dir = -1;
                MonsterSight.transform.rotation = Quaternion.Euler(0, 0, 0);
                SR.flipX = Direction;
            }
            else
            { 
                Dir = 1;
                MonsterSight.transform.rotation = Quaternion.Euler(0, -180, 0);
                SR.flipX = Direction;
            }
           
        }
        
        StartCoroutine(MonsterMoveDirection());
    }

    void PreventionFall()
    {
        Vector2 frontvec = new Vector2(Rb.position.x+ (0.3f * Dir), Rb.position.y);
        Debug.DrawRay(frontvec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down,2, LayerMask.GetMask("Platform"));

        if (rayhit.collider == null)
        { 
            Dir *= -1;
            StopCoroutine(MonsterMoveDirection());
            StartCoroutine(CoolMoveDirection());
            SR.flipX = (Dir > 0) ? true : false;

            
        }
    }

    public IEnumerator MonsterMoveDirection()
    {
        yield return new WaitForSeconds(2f);
        NextDirection = Random.Range(-2, 3);
        MonsterDirection();
    }

    IEnumerator CoolMoveDirection()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(MonsterMoveDirection());
    }
    IEnumerator MoveAnim()
    {
        anim.SetBool("IsMove", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("IsMove", false);
    }


}
