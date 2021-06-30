using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk : MonoBehaviour
{
    public int nextMove;
    private bool isstop = true;
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
            anim.SetBool("IsMove", false);
        }
        Monsterdirection();
    }
    void Monsterdirection()
    {
        if(nextMove > 0)
        {
            sp.flipX = true;
        }
        if (nextMove < 0)
        {
            sp.flipX = false;
        }
    }
    void Monstermove()
    {   
        anim.SetBool("IsMove", true);
        nextMove = Random.Range(-1, 2);
        rb.velocity += new Vector2(nextMove * 3f, 0);
        Invoke("Monstermove", 2);
    }


   
}
