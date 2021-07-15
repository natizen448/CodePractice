using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public bool isFind = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //MonsterMove move = GameObject.FindWithTag("Monster").GetComponent<MonsterMove>();
            isFind = true;
            //move.nextDir = 0;
            //move.CancelInvoke();
           

            Debug.Log("플레이어 발견");
        }
    }
    
    
}
