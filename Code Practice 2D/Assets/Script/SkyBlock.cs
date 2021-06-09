using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y == 0)
        {
          
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.transform.position += new Vector3(0, 0.1f, 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("SkyBlock"))
        {
            collision.isTrigger = false;
        }
    }
}
