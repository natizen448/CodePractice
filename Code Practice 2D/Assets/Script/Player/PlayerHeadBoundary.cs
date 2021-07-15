using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBoundary : MonoBehaviour
{
    PlayerMove pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SkyBlock"))
        { 
            pm.isSkyBlock = true;
        }
    }


}
