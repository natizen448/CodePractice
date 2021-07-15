using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookg : MonoBehaviour
{
    Hook hook;
    PlayerMove pm;
    Rigidbody2D rb;
    public DistanceJoint2D joint2D;
    private int Count;
    public bool coolOff = false;
    void Start()
    {
        hook = GameObject.FindWithTag("Player").GetComponent<Hook>();
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        joint2D = GetComponent<DistanceJoint2D>();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
        //if (pm.anim.GetBool("iswalk"))
        //{   
        //    Debug.Log("움직이는중");
        //    StopCoroutine(CancelHook());
            
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {   
            StartCoroutine(CancelHookCool());
            StopCoroutine(CancelHook());
            joint2D.enabled = true;
            joint2D.autoConfigureDistance = false;
            rb.drag = 100000;
            hook.isAttach = true;
            Debug.Log("붙음");
            StartCoroutine(CancelHook());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") && coolOff)
        {   
            if(pm.anim.GetBool("iswalk"))
            {
                Debug.Log("멈춰!");
                StopAllCoroutines();
            }
            else
            {
                Debug.Log("시작해!");
                StartCoroutine(CancelHook());
            }
            
        }
    }

    IEnumerator CancelHookCool()
    {
        yield return new WaitForSeconds(1f);
        coolOff = true;
        Debug.Log("1초지남");
    }
    IEnumerator CancelHook()
    {   
        if(!pm.anim.GetBool("iswalk"))
        {
            yield return new WaitForSeconds(3f);
            hook.isAttach = false;
            hook.isHookActive = false;
            hook.isLineMax = false;
            joint2D.enabled = false;
            joint2D.autoConfigureDistance = false;
            this.gameObject.SetActive(false);
            rb.drag = 1;
        }
        
    }

    
}
