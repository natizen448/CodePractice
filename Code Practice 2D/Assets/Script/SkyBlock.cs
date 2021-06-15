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
    void Update()
    {
       
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SkyBlock"))
        {
            rb.velocity += new Vector2(0, Jumpspeed) * Time.deltaTime * 3;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("SkyBlock"))
        {
            collision.isTrigger = false;
        }
    }
}

