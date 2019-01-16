using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ足つき
public class PlayerBeta : IPlayerMove {

    Rigidbody2D rigidbody;
    [SerializeField] float speadScale = 8;
    [SerializeField] float maxSpead = 5;
    [SerializeField] float floorSpeed = 10;
 

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
        GetComponent<Animator>().SetBool("Seiming", false);


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
            GetComponent<Animator>().SetBool("Seiming", true);
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

                    GetComponent<Animator>().SetBool("Walkkng", true);
                    if (rigidbody.velocity.magnitude < maxSpead)
                    {
                        rigidbody.AddForce(new Vector3(floorSpeed, 0, 0));
                    }

                }
                if (this.transform.position.x > _mousePosittion.x)
                {
                    GetComponent<Animator>().SetBool("Walkkng", true);
                    if (rigidbody.velocity.magnitude < maxSpead)
                    {
                        rigidbody.AddForce(new Vector3(-floorSpeed, 0, 0));
                    }
                }
            }
            else {
                GetComponent<Animator>().SetBool("Walkkng", false);
            }
        }


        //ここでかく
    }
}
