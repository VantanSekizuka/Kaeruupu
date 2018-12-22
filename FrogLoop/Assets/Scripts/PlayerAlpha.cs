using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ
public class PlayerAlpha : IPlayerMove {

    Rigidbody2D rigidbody;
    [SerializeField] float speadScale;
    [SerializeField] float maxSpead;
    void Start()
    {
        Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
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
            rigidbody.gravityScale = 0.0f;
            if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
            {
                rigidbody.AddForce((InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y)).normalized * speadScale);
                if (rigidbody.velocity.sqrMagnitude > maxSpead * maxSpead)
                {
                    rigidbody.velocity = rigidbody.velocity.normalized * maxSpead;
                }
            }
            else
            {
                rigidbody.velocity *= 0.94f;
            }
        }
        else
        {
            //地面
            rigidbody.gravityScale = 1.0f;
        }
        Debug.Log(InputManager.inputManager.PlayerDrag);
    }
}
