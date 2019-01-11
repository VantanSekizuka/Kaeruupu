using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ
public class PlayerAlpha : IPlayerMove {

    Rigidbody2D rigidbody;
    [SerializeField] float speadScaleWater;
    [SerializeField] float speadScaleGround;
    [SerializeField] float maxSpeadWater;
    [SerializeField] float maxSpeadGround;
    [SerializeField] float waterGravity = 0.2f;
    [SerializeField] float groundJumpPower = 0.2f;
    public bool JumpFlag { get; set; }
    public bool JumpSet { get; set; }
    public bool Jumping { get; set; }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<PlayerStatus>().status = PlayerStatus.Status.ALPHA;
        JumpFlag = false;
        JumpSet = false;
        Jumping = false;
    }

    void OnEnable()
    {
        JumpSet = false;
    }

    void FixedUpdate()
    {
        Move();
        Debug.Log(JumpFlag);
    }

    protected override void Move()
    {
        rigidbody.gravityScale = 1.0f;
        if (InputManager.inputManager.PlayerDrag && JumpFlag)
        {
            rigidbody.gravityScale = 0.0f;
            rigidbody.velocity *= 0.92f;
            JumpSet = true;
            Debug.Log("jump");
        }else if (!InputManager.inputManager.PlayerDrag && JumpSet)
        {
            JumpSet = false;
            Jumping = true;
            Vector2 jumpDir = (new Vector2(transform.position.x, transform.position.y) - InputManager.inputManager.tapPosition) * 150;
            if (OnGroundFlag)
            {
                jumpDir *= groundJumpPower;
            }
            rigidbody.AddForce(jumpDir);
        }
        else
        {
            if (InWaterFlag)
            {
                WaterMove();
            }
            else if(OnGroundFlag)
            {
                //GroundMove();
                JumpFlag = true;
            }
            else
            {
                JumpFlag = false;
            }
        }
    }

    void GroundMove()
    {
        if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
        {
            var _velX = (InputManager.inputManager.tapPosition.x - transform.position.x);
            if (_velX > 0.0f)
            {
                _velX = 1.0f;
            }
            else
            {
                _velX = -1.0f;
            }
            rigidbody.AddForce(_velX * speadScaleGround * Vector2.right);
            
            if (rigidbody.velocity.x * rigidbody.velocity.x > maxSpeadGround * maxSpeadGround)
            {
                if (rigidbody.velocity.x < 0.0f)
                {
                    rigidbody.velocity = new Vector2(-maxSpeadGround, rigidbody.velocity.y);
                }
                else
                {
                    rigidbody.velocity = new Vector2(maxSpeadGround, rigidbody.velocity.y);
                }
            }
        }
    }

    void WaterMove()
    {
        rigidbody.gravityScale = waterGravity;
        if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
        {
            rigidbody.AddForce((InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y)).normalized * speadScaleWater);
            if (rigidbody.velocity.sqrMagnitude > maxSpeadWater * maxSpeadWater)
            {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeadWater;
            }
        }
        rigidbody.velocity *= 0.92f;
    }
}
