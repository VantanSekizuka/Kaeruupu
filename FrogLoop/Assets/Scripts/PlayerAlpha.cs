using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ
public class PlayerAlpha : IPlayerMove {

    Rigidbody2D rigidbody;
    [SerializeField] float speadScale;
    [SerializeField] float maxSpead;
    public bool JumpFlag { get; set; }
    void Start()
    {
        Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
        JumpFlag = false;
        GetComponent<PlayerStatus>().status = PlayerStatus.Status.ALPHA;
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
        
        if (InputManager.inputManager.PlayerDrag && JumpFlag)
        {
            rigidbody.gravityScale = 0.0f;
            rigidbody.velocity *= 0.85f;
            Debug.Log("awawa");
        }
        else
        {
            if (InWaterFlag)
            {
                WaterMove();
            }
            else
            {
                GroundMove();
            }
        }
    }

    void GroundMove()
    {
        rigidbody.gravityScale = 1.0f;
    }

    void WaterMove()
    {
        rigidbody.gravityScale = 0.2f;
        if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
        {
            rigidbody.AddForce((InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y)).normalized * speadScale);
            if (rigidbody.velocity.sqrMagnitude > maxSpead * maxSpead)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpead;
            }
        }
        //else
        {
            rigidbody.velocity *= 0.94f;
        }
    }
}
