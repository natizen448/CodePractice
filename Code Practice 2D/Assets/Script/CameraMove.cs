using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    void Start()
    {

    }


    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }

}
