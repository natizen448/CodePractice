using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemakeMonsterWalk : MonoBehaviour
{
    [SerializeField] private float MonsterMoveSpeed;


    SpriteRenderer SR;
    Rigidbody2D Rb;
    private int NextDirection;
    private int Dir;
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
    }
    void Walk()
    {
        if(!CancelAtt)
        {
            this.transform.position += new Vector3(MonsterMoveSpeed * Dir, 0,0) * Time.deltaTime;
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
            if(NextDirection > 0)
            {
                Dir = -1;
            }
            else
            {
                Dir = 1;
            }
        }
        SR.flipX = Direction;
        StartCoroutine(MonsterMoveDirection());
    }

    void PreventionFall()
    {
        Vector2 frontvec = new Vector2(Rb.position.x, Rb.position.y);
        Debug.DrawRay(Rb.position, Vector3.down * 2, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(frontvec, Vector3.down,2, LayerMask.GetMask("Platform"));

        if (rayhit.collider == null)
        {
            Debug.Log("바닥에 아무것도없다.");
            Dir *= -1;
        }
    }
    IEnumerator MonsterMoveDirection()
    {
        yield return new WaitForSeconds(2f);
        NextDirection = Random.Range(-2, 3);
        MonsterDirection();
    }

    
}
