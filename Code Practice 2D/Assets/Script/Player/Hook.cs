using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Rigidbody2D rb;
    Vector2 hookDir;
    public bool isHookActive;
    public bool isLineMax;
    public bool isAttach;

    PlayerMove pm;
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;
        pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if(Input.GetKeyDown(KeyCode.E))
        {   
            hookDir = ((Vector2.up + new Vector2(pm.dir * 2, 0) / 2));
            hook.position = transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
        }

        if(isHookActive && !isLineMax &&!isAttach)
        {
            hook.Translate(hookDir.normalized * Time.deltaTime * 30);
            if(Vector2.Distance(transform.position,hook.position) > 5)
            {
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax &&!isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime *30 );
            if(Vector2.Distance(transform.position,hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if(isAttach)
        {   
            if (Input.GetKeyDown(KeyCode.E))
            {
                isAttach = false;
                isHookActive = false;
                isLineMax = false;
                hook.GetComponent<Hookg>().coolOff = false;
                hook.GetComponent<Hookg>().joint2D.enabled = false;
                hook.GetComponent<Hookg>().joint2D.autoConfigureDistance = false;
                hook.gameObject.SetActive(false);
                rb.drag = 1;
            }
           
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor") && isAttach)
        {
            hook.GetComponent<Hookg>().joint2D.distance -= 0.2f;
            
        }

    }
}
