using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private float Raylength;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   PlayerMove pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        
        if (Input.GetKey(KeyCode.F))
        {
            Raylength += 20f * Time.fixedDeltaTime;
            Vector2 dir = ((Vector2.up + new Vector2(pm.dir * 2,0) / 2));
            RaycastHit2D Rope = Physics2D.Raycast(this.transform.position, dir,Raylength);
            Debug.DrawRay(this.transform.position, dir * Raylength, new Color(0, 1, 0));
         
        }
        else
        {
            Raylength = 0;
        }
    }
}
