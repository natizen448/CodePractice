using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonoBehaviour
{
    public int nextMove;
    private int MoveSpeed;
    private bool ismove = false;
    Rigidbody2D rb;
    [SerializeField] Animator anim;
    SpriteRenderer sp;
    void Awake()
    {
        Monstermove();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        if(rb.velocity.x == 0)
        {
            //anim.SetBool("IsMove", false);
        }
        if(ismove)
        {
            this.transform.position += new Vector3(MoveSpeed, 0, 0) * Time.deltaTime;
        }
        Monsterdirection();
    }
    void Monsterdirection()
    {
        if(nextMove > 0)
        {
            sp.flipX = true;
            MoveSpeed = 3;
        }
        if (nextMove < 0)
        {
            sp.flipX = false;
            MoveSpeed = -3;
        }
    }
    void Monstermove()
    {
        nextMove = Random.Range(-3, 4);
        ismove = true;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(2f);
        ismove = false;
        StartCoroutine(NextBehavior());
    }
    IEnumerator NextBehavior()
    {
        yield return new WaitForSeconds(2f);
        Monstermove();
    }
}
