using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]GameObject player;
    [SerializeField]float timeOfset;
    [SerializeField]Vector2 posOffset;
    void Start()
    {

    }


    void Update()
    {
        //ī�޶� current ����
        Vector3 startPos = transform.position;


        //�÷��̾� current ����
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -7;

        transform.position = Vector3.Lerp(startPos, endPos, timeOfset * Time.deltaTime);
    }

}
