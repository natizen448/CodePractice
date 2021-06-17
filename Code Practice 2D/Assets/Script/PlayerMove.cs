using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    [SerializeField] private Animator anim;
    private float moveSpeed = 3f;
    private float jumpSpeed = 5f;
    public int Jumpcount = 1;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlayer();
        if (Input.GetMouseButton(1))
        {
            moveSpeed = 1f;
        }
        else
        {
            moveSpeed = 3f;
        }
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
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("iswalk", true);
        }
        else
        {
            anim.SetBool("iswalk", false);
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

        if(rb.velocity.y < 0)
        {
           anim.SetBool("isjump", false);
        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Jumpcount = 1;
        }   
    }

   
}

