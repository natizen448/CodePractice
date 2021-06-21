using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private Animator anim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float jumpSpeed;
    public int Jumpcount = 1;
    public bool isDash = false;
    private bool isDashCoolDown = true;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        dash();
        Sliding();
        DefenseSpeed();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-moveSpeed,0,0) * Time.deltaTime;
            if(!Input.GetMouseButton(1))
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
      
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;

            if (!Input.GetMouseButton(1))
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.Space) && Jumpcount == 1)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
            anim.SetBool("isjump", true);
            if (rb.velocity.y > 0)
            {
                Jumpcount--;

            }
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isjump", false);
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

    void dash()
    {
        if(Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift) && isDashCoolDown)
        {   
            isDash = true;
            StartCoroutine("Dash", -1);
            isDashCoolDown = false;
            StartCoroutine(DashCool());
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift) && isDashCoolDown)
        {   
            isDash = true;
            StartCoroutine("Dash", 1);
            isDashCoolDown = false;
            StartCoroutine(DashCool());
        }
    }

    void Sliding()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("isslid", true);
        }
        else
        {
            anim.SetBool("isslid", false);
        }
    }

    void DefenseSpeed()
    {
        if (Input.GetMouseButton(1))
        {
            moveSpeed = 1f;
        }
        else
        {
            moveSpeed = 3f;
        }
    }

    IEnumerator Dash(int direction)
    {
        rb.velocity += new Vector2(dashSpeed * direction, 0);
        rb.drag = 2f;
        yield return new WaitForSeconds(0.7f);
        isDash = false;
        rb.drag = 1f;
    }

    IEnumerator DashCool()
    {   
        yield return new WaitForSeconds(3f);
        isDashCoolDown = true;
    }

    

}

