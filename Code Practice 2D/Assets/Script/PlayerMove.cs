using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 3f;
    [SerializeField]private float jumpSpeed = 5f;
   
    public int Jumpcount = 1;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlayer();
        
    }
    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-moveSpeed,0,0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && Jumpcount == 1)
        {
            rb.velocity += new Vector2(0, jumpSpeed);
            if (rb.velocity.y > 0)
            {
                Jumpcount--;
                
            }
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

