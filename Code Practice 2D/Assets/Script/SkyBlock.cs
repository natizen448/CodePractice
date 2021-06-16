using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
    [SerializeField] private float Jumpspeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (collision.CompareTag("SkyBlock") && rb.velocity.y > 0)
        {
            transform.position += new Vector3(0, Jumpspeed,0) * Time.deltaTime;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("SkyBlock") && rb.velocity.y > 0)
        {
            collision.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SkyBlock") && rb.velocity.y > 0)
        {
            collision.collider.isTrigger = true;
        }
    }
}

