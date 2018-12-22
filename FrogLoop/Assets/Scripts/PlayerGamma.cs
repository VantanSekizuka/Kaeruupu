using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエル
public class PlayerGamma : IPlayerMove
{
    Rigidbody2D rigidbody;

    [SerializeField]
    private float _speed;//カエルのスピード
    [SerializeField]
    private float _jumpingPower;//ジャンプ力

    private float _oneSide = 0.15f;//スプライトの一辺の長さ

    private Vector2 _playerPosition;
    private Vector2 _mousePosition;
    private Vector2 _dragPosition;

    private bool _jump;//ジャンプするタイミングを判断する
    void Start()
    {
        //Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        //Debug.Log("Enable");
    }

    void FixedUpdate()//ここメイン
    {

        rigidbody.gravityScale = 1.0f;
        if (InputManager.inputManager.PlayerDrag == true)
        {
            _jump = true;
            _dragPosition = InputManager.inputManager.tapPosition;
            
        }
        else if (InputManager.inputManager.PlayerDrag == false)
        {
            Debug.Log(_dragPosition);
            Debug.Log(_jump);
            if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)//プレイヤー移動
            {
                _playerPosition = this.transform.position;
                _mousePosition = InputManager.inputManager.tapPosition;
                Move();
            }
            if (_jump == true)
            {
                rigidbody.AddForce((_playerPosition - _dragPosition) * _jumpingPower);
                _jump = false;
            }
        }

    }

    protected override void Move()
    {

        if (_playerPosition.x + _oneSide / 2 < _mousePosition.x)//プレイヤーより右側タップ
        {
            _playerPosition += new Vector2(_speed, 0);
        }
        else if (_playerPosition.x - _oneSide / 2 > _mousePosition.x)//プレイヤーより左側をタップ
        {
            _playerPosition -= new Vector2(_speed, 0);
        }
        this.transform.position = _playerPosition;//変更したポジションを参照
    }
}
