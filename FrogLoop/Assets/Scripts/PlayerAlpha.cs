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
            //水中
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
            {
                GetComponent<Rigidbody2D>().AddForce(10*(InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y)));
            }
        }
        else
        {
            //地面
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
        Debug.Log(InputManager.inputManager.PlayerDrag);
    }
}
