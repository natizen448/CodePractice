using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookg : MonoBehaviour
{
    Hook hook;
    public DistanceJoint2D joint2D;
    void Start()
    {
        hook = GameObject.FindWithTag("Player").GetComponent<Hook>();
        joint2D = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            joint2D.enabled = true;
            joint2D.autoConfigureDistance = false;
            hook.isAttach = true;
            Debug.Log("∫Ÿ¿Ω");
        }
    }
}
