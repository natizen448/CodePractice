using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{   
    Slider hp;
    PlayerInfo pl;

    void Start()
    {
        pl = GameObject.FindWithTag("Player").GetComponent<PlayerInfo>();
        hp = GetComponent<Slider>();
        hp.value = 100;
    }
    void Update()
    {
        HP();
        if(hp.value == 0)
        {   
            this.gameObject.SetActive(false);
        }
    }

    void HP()
    {
        hp.value = pl.HP;
        Debug.Log(pl.HP);
    }
}
