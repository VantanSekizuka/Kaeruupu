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
    private InputManager _ipm;
    void Start()
    {
        _ipm = InputManager.inputManager;
        //Debug.Log("Start");
    }

    void OnEnable()//
    {

        //Debug.Log("Enable");
    }

    void FixedUpdate()//ここメイン
    {
        if (_ipm.state == InputManager.TouchState.PRESSING)
        {
            _mousePosition = _ipm.tapPosition;
            _playerPos = this.transform.position;
            Move();
        }
        if (_ipm.PlayerDrag == true)
        {
            Debug.Log(_ipm.PlayerDrag);
        }
    }

    protected override void Move()
    {

        if (0 < _mousePosition.x)//プレイヤーより右側タップ
        {

            _playerPos += new Vector2(_speed, 0);
        }
        else if (0 > _mousePosition.x)//プレイヤーより左側をタップ
        {
            _playerPos -= new Vector2(_speed, 0);
        }
        this.transform.position = _playerPos;
    }
}
