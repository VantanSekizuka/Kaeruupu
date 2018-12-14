using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ
public class PlayerAlpha : IPlayerMove {
    void Start()
    {
        Debug.Log("Start");
    }

    void OnEnable()
    {
        Debug.Log("Enable");
    }

    void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        if (InWaterFlag)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            GetComponent<Rigidbody2D>().velocity *= 0.8f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
}
