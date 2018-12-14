using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ足つき
public class PlayerBeta : IPlayerMove {
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

    }

    protected override void Move()
    {

    }
}
