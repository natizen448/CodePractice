using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaffolding : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMove pm = GameObject.Find("Player").GetComponent<PlayerMove>();
        if (collision.gameObject.tag == "Floor" && !pm.isSlid)
        {
            pm.Jumpcount = 1;
        }

        if(collision.gameObject.tag == "SkyBlock")
        {

        }
    }
}