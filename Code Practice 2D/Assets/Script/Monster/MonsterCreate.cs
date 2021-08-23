using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    [SerializeField] GameObject monster;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(monster, this.transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
