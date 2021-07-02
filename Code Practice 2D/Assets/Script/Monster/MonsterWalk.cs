using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonoBehaviour
{
    private int nextMove;
    private int MoveSpeed;
    private bool ismove = false;
    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField] Animator anim;
    
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
            this.transform.position += new Vector3(MoveSpeed * 2f, 0, 0) * Time.deltaTime;
        }
        Monsterdirection();
        MonsterAI();
    }
    void Monsterdirection()
    {
        if(nextMove > 0)
        {
            sp.flipX = true;
            MoveSpeed = 1;
        }
        if (nextMove < 0)
        {
            sp.flipX = false;
            MoveSpeed = -1;
        }
    }
    void Monstermove()
    {
        nextMove = Random.Range(-3, 4);
        ismove = true;
        StartCoroutine(Move());
    }
    void MonsterAI()
    {
        Vector2 frontVec = new Vector2(rb.position.x + MoveSpeed * 0.3f, rb.position.y);
        Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayhit.collider == null)
        {
            nextMove *= -1;
        }
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
