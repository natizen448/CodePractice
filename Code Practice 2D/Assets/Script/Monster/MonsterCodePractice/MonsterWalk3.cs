using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalk3 : MonoBehaviour
{   
    private int nextMove;
    public int moveSpeed;
    public bool isFindPlayer = false;
    public bool cantFindPlayer = false;
    public bool isMove = false;
    public bool startMove = false;
    Rigidbody2D rb;
    SpriteRenderer sp;
    [SerializeField] public Animator anim;
    [SerializeField] GameObject monsterSight;

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
        if(startMove)
        {
            StopCoroutine(Move());
            StopCoroutine(NextBehavior());

            Monstermove();
            startMove = false;
        }
            
       if(isMove)
       {    
            this.transform.position += new Vector3(moveSpeed * 2f, 0, 0) * Time.deltaTime;
       }
       
        Monsterdirection();
        MonsterAI();
    }
    void Monsterdirection()
    {
        if(nextMove > 0)
        {   
            sp.flipX = true;
            moveSpeed = 1;
        }
        if (nextMove < 0)
        {
            
            sp.flipX = false;
            moveSpeed = -1;
        }
    }
    void Monstermove()
    {
        nextMove = Random.Range(-3, 4);
        isMove = true;
        StartCoroutine(Move());
    }
    void MonsterAI()
    {
        Vector2 frontVec = new Vector2(rb.position.x + moveSpeed * 0.3f, rb.position.y);
        Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if(rayhit.collider == null)
        {
            nextMove *= -1;
        }
    }
    
  
    IEnumerator Move()
    {
        anim.SetBool("IsMove", true);
        yield return new WaitForSeconds(2f);
        isMove = false;
        StartCoroutine(NextBehavior());
    }
    IEnumerator NextBehavior()
    {   anim.SetBool("IsMove", false);
        yield return new WaitForSeconds(2f);
        
        Monstermove();
        
       
        
    }
  
   
    
}
