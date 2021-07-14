using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public LineRenderer line;
    public Transform hook;
    Vector2 hookDir;
    public bool isHookActive;
    public bool isLineMax;
    public bool isAttach;
    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);

        if(Input.GetKeyDown(KeyCode.E))
        {   PlayerMove pm = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
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
            hook.GetComponent<Hookg>().joint2D.enabled = false;
                hook.GetComponent<Hookg>().joint2D.autoConfigureDistance = true;
                hook.gameObject.SetActive(false);
            }
           
        }
    }
}
