using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエル
public class PlayerGamma : IPlayerMove
{
    Rigidbody2D rigidbody;

    [SerializeField]
    private float _maxSpeed;//カエルのスピード
    [SerializeField]
    private float _speed;//カエルのスピード
    [SerializeField]
    private float _jumpingPower;//ジャンプ力

    private float _oneSide = 0.15f;//スプライトの一辺の長さ

    private Vector2 _playerPosition;
    private Vector2 _mousePosition;
    private Vector2 _dragPosition;

    public bool JumpingFlag { get; set; }//ジャンプするタイミングを判断する
    void Start()
    {
        //Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
        JumpingFlag = false;

    }

    void OnEnable()
    {
        //Debug.Log("Enable");
        JumpingFlag = false;

    }

    void FixedUpdate()//ここメイン
    {
        PlayerDirection();
        rigidbody.gravityScale = 1.0f;
        if (Input.GetKeyDown("a"))
        {
            Debug.Log(JumpingFlag); 
        }
        if (JumpingFlag == false)
        {
            if (InputManager.inputManager.PlayerDrag == true)
            {

                _dragPosition = InputManager.inputManager.tapPosition;
                _playerPosition = this.transform.position;

                if (InputManager.inputManager.state == InputManager.TouchState.RELEASE)
                {
                    GetComponent<Animator>().SetTrigger("Jump");
                    Jump();
                    JumpingFlag = true;
                }

            }
            else if (InputManager.inputManager.PlayerDrag == false)
            {

                if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)//プレイヤー移動
                {
                    _playerPosition = this.transform.position;
                    _mousePosition = InputManager.inputManager.tapPosition;
                    GetComponent<Animator>().SetBool("Walkkng", true);
                    Move();
                }
                else
                {
                    GetComponent<Animator>().SetBool("Walkkng", false);

                }

            }
        }


    }

    protected override void Move()
    {

        if (_playerPosition.x + _oneSide / 2 < _mousePosition.x)//プレイヤーより右側タップ
        {
            
            if (_maxSpeed <= rigidbody.velocity.magnitude)
            {
                rigidbody.velocity = new Vector2(_maxSpeed,0);
            }
            else
            {
                rigidbody.AddForce(new Vector3(_speed, 0, 0));
            }
        }
        else if (_playerPosition.x - _oneSide / 2 > _mousePosition.x)//プレイヤーより左側をタップ
        {
            
            if (_maxSpeed <= rigidbody.velocity.magnitude)
            {
               
                rigidbody.velocity = new Vector2(-_maxSpeed, 0);

            }
            else
            {
                rigidbody.AddForce(new Vector3(-_speed, 0, 0));
            }

        }
        
    }
    void Jump()
    {
        rigidbody.AddForce((_playerPosition - _dragPosition) * _jumpingPower);
        Debug.Log("JUMP");
    }
}
