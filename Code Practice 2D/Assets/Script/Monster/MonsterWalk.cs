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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Monstermove();
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
        if(isstop)  
        {   
            isstop = false;
            StartCoroutine(move());
            
            
        }
 
    
    }

    IEnumerator Think()
    {    
        anim.SetBool("IsMove", false); 
        nextMove = Random.Range(-1, 2);
        yield return new WaitForSeconds(3f);
        
        isstop = true;  
    }
    IEnumerator move()
    {
        anim.SetBool("IsMove", true);
        rb.velocity += new Vector2(nextMove * 3f, 0);
        StartCoroutine(Think());
        yield return null;
    }
}
