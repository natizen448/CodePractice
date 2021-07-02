using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSight : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Sight();
    }
    void Sight()
    {
        MonsterWalk mw = GameObject.Find("Monster").GetComponent<MonsterWalk>();
        Vector2 frontVec = new Vector2(rb.position.x + mw.MoveSpeed * 1f, rb.position.y);
        Debug.DrawRay(rb.position, new Vector3(mw.MoveSpeed* 3f , 0, 0), new Color(0, 1, 0)) ;
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec * 3f, Vector3.forward, 1);

        if(rayhit.collider != null)
        {
            Debug.Log("Á¢ÃËÇßµû.");
        }
    }
}
