using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBlock : MonoBehaviour
{
    private bool isSkyblock = false;
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            if(!isSkyblock)
            {
                collision.transform.position += new Vector3(0, 1.3f, 0);
                isSkyblock = true;
            }
            if(isSkyblock)
            {
                col.isTrigger = false;
            }
           
        }
    }
}
