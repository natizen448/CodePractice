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
            this.transform.position += new Vector3(-moveSpeed,0,0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && !IsJump)
        {
            this.transform.position += new Vector3(0, jumpSpeed, 0) * Time.deltaTime;
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
