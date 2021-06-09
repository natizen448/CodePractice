using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //[SerializeField]
    //GameObject Player;
    //void Start()
    //{

    //}


    //void Update()
    //{
    //    this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y,-10);
    //}
    [SerializeField]
    GameObject player;

    [SerializeField]
    float timeOfset;

    [SerializeField]
    Vector2 posOffset;



    void FixedUpdate()
    {

        //카메라 current 지점
        Vector3 startPos = transform.position;


        //플레이어 current 지점
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOfset * Time.deltaTime);
    }
}
