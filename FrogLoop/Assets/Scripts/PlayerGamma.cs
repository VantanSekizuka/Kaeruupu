using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエル
public class PlayerGamma : IPlayerMove
{
    [SerializeField]
    private float _speed;//カエルのスピード

    private Vector2 _playerPos;
    private Vector2 _mousePosition;
    void Start()
    {
        //Debug.Log("Start");
    }

    void OnEnable()
    {
       //Debug.Log("Enable");
    }

    void FixedUpdate()//ここメイン
    {

        if (InputManager.inputManager.state == InputManager.TouchState.PRESSING)
        {
            _playerPos = this.transform.position;
            _mousePosition = InputManager.inputManager.tapPosition;
            Move();
        }


    }

    protected override void Move()
    {

        //if (_playerPos.x < _mousePosition.x)//プレイヤーより右側タップ
        //{
        //    _playerPos += new Vector2(_speed, 0);
        //}
        //else if (_playerPos.x > _mousePosition.x)//プレイヤーより左側をタップ
        //{
        //    _playerPos -= new Vector2(_speed, 0);
        //}
        //this.transform.position = _playerPos;
        Debug.Log(InputManager.inputManager.PlayerDrag);
    }
}
