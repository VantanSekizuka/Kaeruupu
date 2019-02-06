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
    [SerializeField] float jumpPower = 50.0f;
    public bool Jumping { get; set; }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Jumping = false;
    }

    void OnEnable()
    {
    }

    void FixedUpdate()
    {
        PlayerDirectionJump();
        Move();
    }

    public void PlayerDirectionJump()
    {
        float val = 1.0f;
        if (Input.GetMouseButton(0))
        {
            if (this.transform.position.x < InputManager.inputManager.tapPosition.x)
            {
                transform.localScale = new Vector3(val, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-val, 1, 1);
            }
        }
    }

    [SerializeField] ContactFilter2D filter2D;
    protected override void Move()
    {
        rigidbody.gravityScale = 1.0f;
        if (InputManager.inputManager.TapFlag && (rigidbody.IsTouching(filter2D)))
        {
            Jumping = true;
            Vector2 jumpDir = ((InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y))).normalized * jumpPower;
            if (OnGroundFlag)
            {
                jumpDir *= groundJumpPower;
                Debug.Log("jump");
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
                GetComponent<Animator>().SetBool("IfMove", false);
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
        GetComponent<Animator>().SetBool("IfMove", true);
    }
}
