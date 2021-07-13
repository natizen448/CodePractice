using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaffolding : MonoBehaviour
{   
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        if (collision.gameObject.tag == "Floor" && !pm.isSlid)
        {
            pm.jumpCount = 1;
        }
        if (collision.gameObject.tag == "SkyBlock" && !pm.isSlid)
        {
            pm.jumpCount = 1;
        }
     
    }


  
}
