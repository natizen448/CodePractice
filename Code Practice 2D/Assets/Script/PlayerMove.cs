using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpSpeed = 5f;

    private bool IsJump = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MovePlayer();
        isFloor();
    }
    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && !IsJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            IsJump = true;
        }
    }
    void isFloor()
    {
        if (rb.velocity.y == 0)
        {
            IsJump = false;
        }
    }


}
