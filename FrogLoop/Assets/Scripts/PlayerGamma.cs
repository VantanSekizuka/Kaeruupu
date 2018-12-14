using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエル
public class PlayerGamma : IPlayerMove {
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
