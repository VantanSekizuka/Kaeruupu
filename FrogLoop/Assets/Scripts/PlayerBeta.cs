using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ足つき
public class PlayerBeta : IPlayerMove {

    Rigidbody2D rigidbody;

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
        
        //ここでむーぶよびだす
    }

    protected override void Move()
    {
        
      

        if (InWaterFlag)
        {
            //水中
            rigidbody.gravityScale = 0.0f;
            if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
            {
                rigidbody.AddForce(10 * (InputManager.inputManager.tapPosition - new Vector2(transform.position.x, transform.position.y)));
            }
            rigidbody.velocity *= 0.9f;
        }
        else
        {
            //地面
            rigidbody.gravityScale = 1.0f;

            Vector2 _mousePosittion = InputManager.inputManager.tapPosition;
            if (Input.GetMouseButton(0))
            {
                if (this.transform.position.x < _mousePosittion.x)
                {
                    this.transform.position += new Vector3(0.01f, 0, 0);

                }
                if (this.transform.position.x > _mousePosittion.x)
                {
                    this.transform.position -= new Vector3(0.01f, 0, 0);
                }
            }
        }


        //ここでかく
    }
}
