using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
    [SerializeField] private float Jumpspeed;
    private int flashcount = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       
    }
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();


        if(collision.gameObject.tag == "SkyBlock")
        {
            if (pm.isJump && flashcount == 1)
            {   
                pm.isJump = false;  
                Debug.Log("´ê¾ÒÀ½");   
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Jumpspeed, this.transform.position.z);
                flashcount--;
                
            }
            
        }

        if(collision.gameObject.tag == "SkyBlock")
        {
            if(rb.velocity.y == 0)
            {
                flashcount = 1;
            }
        }
    }
}
