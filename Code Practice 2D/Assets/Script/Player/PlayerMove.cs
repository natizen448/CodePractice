using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public Animator anim;
    SpriteRenderer sr;
    private float moveSpeed;
    private float dashSpeed;
    private float jumpSpeed;
    public int jumpCount = 1;
    public bool isDash = false;
    public bool isSlid = false;
    public bool isSkyBlock = false;
    public bool isLeft = false;
    public bool isRight = false;
    private int jump = 0;
    public int dir;
    private bool isDashCoolDown = true;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc2;
    [SerializeField] GameObject scaffolding;
    [SerializeField] GameObject playerHeadBoundary;
    

    PlayerInfo pl;
    Hook hook;
    void Start()
    {   
        
        rb = GetComponent<Rigidbody2D>();
        cc2 = GetComponent<CapsuleCollider2D>();
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        hook = GameObject.FindWithTag("Player").GetComponent<Hook>();
    }

    void Update()
    {
        anim = pl.anim;
        moveSpeed = pl.speed;
        dashSpeed = pl.dashSpeed;
        jumpSpeed = pl.jumpSpeed;
        MovePlayer();
        Dash();
        Sliding();
        DoubleJump();
        if (isSkyBlock)
            StartCoroutine(SkyBlock());
        

        if(hook.isAttach)
        {
            if(dir == -1)
            {
                isRight = true;
            }
            if (dir == 1)
            {
                isLeft = true;
            }

        }
        else
        {
            isRight = false;
            isLeft = false;
        }
    }
    

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A) && !isLeft)
        {
            this.transform.position += new Vector3(-moveSpeed,0,0) * Time.deltaTime;
            if(!Input.GetMouseButton(1))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                dir = -1;
            }
        }
      
        if (Input.GetKey(KeyCode.D) && !isRight)
        {
            this.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;

            if (!Input.GetMouseButton(1))
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                dir = 1;
            }
        }


        if (Input.GetKey(KeyCode.Space) && jumpCount == 1)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
            anim.SetBool("isjump", true);
            scaffolding.SetActive(false);
            playerHeadBoundary.SetActive(true);
            if (rb.velocity.y > 0)
            {
                jumpCount--;
            }
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isjump", false);
            scaffolding.SetActive(true);
            playerHeadBoundary.SetActive(false);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("iswalk", true);
        }
        else
        {
            anim.SetBool("iswalk", false);
        }
      
    }

    void Dash()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift) && isDashCoolDown)
        {   
            isDash = true;
            StartCoroutine(Dash(-1));
            isDashCoolDown = false;
            StartCoroutine(DashCool());
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift) && isDashCoolDown)
        {   
            isDash = true;
            StartCoroutine(Dash(1));
            isDashCoolDown = false;
            StartCoroutine(DashCool());
        }
    }

    void Sliding()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("isslid", true);
            isSlid = true;
        }
        else
        {
            anim.SetBool("isslid", false);
            isSlid = false;
        }

        if(anim.GetBool("isslid"))
        {
            cc2.size = new Vector2(1.625701f, 1.056339f);
            cc2.direction = CapsuleDirection2D.Horizontal;
            cc2.offset = new Vector2(0.01975906f, -0.62f);
        }
        else
        {
            cc2.size = new Vector2(0.81f, 1.24f);
            cc2.direction = CapsuleDirection2D.Vertical;
            cc2.offset = new Vector2(0.01975906f, -0.435951f);
        }
    }

    void DoubleJump()
    {   

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump += 1;
            StartCoroutine(Jumpcool());
        }
        if(jump > 1)
        {
            StartCoroutine(DoubleJumpcor());
        }
    }

    IEnumerator Dash(int direction)
    {
        rb.velocity += new Vector2(dashSpeed * direction, 0);
        rb.drag = 2f;
        yield return new WaitForSeconds(0.3f);
        isDash = false;
        rb.drag = 1f;
    }

    IEnumerator DashCool()
    {   
        yield return new WaitForSeconds(3f);
        isDashCoolDown = true;
    }
    IEnumerator SkyBlock()
    {   
        yield return null;
        transform.position += new Vector3(0, 1.2f, 0);
        isSkyBlock = false; 
    }
    IEnumerator Jumpcool()
    {   
        yield return new WaitForSeconds(0.2f);
        jump = 0;
    }
    IEnumerator DoubleJumpcor()
    {   
        rb.velocity += new Vector2(7f, 0);
        return null;
    }

}

