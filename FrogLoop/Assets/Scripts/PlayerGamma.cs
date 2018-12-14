using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カエル
public class PlayerGamma : IPlayerMove
{
    [SerializeField]
    private float _speed;//カエルのスピード

    private Vector3 _playerPos;
    private Vector3 _mousePosition;
    void Start()
    {
        //Debug.Log("Start");
    }

    void OnEnable()//
    {

        //Debug.Log("Enable");
    }

    void FixedUpdate()//ここメイン
    {
        if (Input.GetMouseButton(0))
        {
            _mousePosition = Input.mousePosition - new Vector3(Screen.width / 2, 0, 0);
            _playerPos = this.transform.position;           
            Move();
        }
    }

    protected override void Move()
    {

        if (0 < _mousePosition.x)//プレイヤーより右側タップ
        {

            _playerPos += new Vector3(_speed, 0, 0);
        }
        else if (0 > _mousePosition.x)//プレイヤーより左側をタップ
        {
            _playerPos -= new Vector3(_speed, 0, 0);
        }
        this.transform.position = _playerPos;
    }
}
