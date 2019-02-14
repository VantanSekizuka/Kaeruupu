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
    [SerializeField]
    private GameObject _arrowSprite;//矢印の画像


    private float _oneSide = 0.15f;//スプライトの一辺の長さ

    private Vector2 _playerPosition;
    private Vector2 _mousePosition;
    private Vector2 _dragPosition;
    private float _max = 5.0f;//ジャンプの引っ張りの最大値
    private float _min = 1.0f;//ジャンプの引っ張りの最小値

    public bool JumpingFlag { get; set; }//ジャンプするタイミングを判断する

    public AudioClip clip;
    private AudioSource source;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        //Debug.Log("Start");
        rigidbody = GetComponent<Rigidbody2D>();
        JumpingFlag = false;
        _arrowSprite.SetActive(false);

    }

    void OnEnable()
    {
        //Debug.Log("Enable");
        JumpingFlag = false;
        _arrowSprite.SetActive(false);
    }

    void FixedUpdate()//ここメイン
    {
        GPlayerDirection();
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

                _arrowSprite.transform.position = _playerPosition;
                _arrowSprite.transform.localScale = new Vector2((_playerPosition.y - _dragPosition.y), 0.5f);
                _arrowSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, GetAngle(_playerPosition,_dragPosition));
                _arrowSprite.SetActive(true);

                if (_playerPosition.x -_dragPosition.x >= 0)
                {
                    this.transform.localScale = new Vector2(1,1);
                }
                else
                {
                    this.transform.localScale = new Vector2(-1, 1);
                }

                if (InputManager.inputManager.state == InputManager.TouchState.RELEASE)
                {
                    Jump();
                    _arrowSprite.SetActive(false);
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
                rigidbody.velocity = new Vector2(_maxSpeed, 0);
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
        if (_playerPosition.y - _dragPosition.y > _min)
        {
            if (_playerPosition.y - _dragPosition.y < _max)
            {
                rigidbody.AddForce((_playerPosition - _dragPosition) * _jumpingPower);
            }
            else
            {
                rigidbody.AddForce(new Vector2(_playerPosition.x-_dragPosition.x,_max)* _jumpingPower);
            }
                JumpingFlag = true;
                GetComponent<Animator>().SetTrigger("Jump");
                source.PlayOneShot(clip);
                Debug.Log("JUMP");
        }
    }
    void GPlayerDirection()
    {
        if (Input.GetMouseButton(0))
        {
            if (_playerPosition.x - _mousePosition.x < _min)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (InputManager.inputManager.PlayerDrag == true)
        {
            if (_playerPosition.y - _dragPosition.y > _min)
            {
                if (_playerPosition.x + _oneSide > _dragPosition.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (_playerPosition.x - _oneSide < _dragPosition.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }
    }
    private float GetAngle(Vector2 pPos,Vector2 dPos)
    {
        float dx = pPos.x - dPos.x;
        float dy = pPos.y - dPos.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    public void Eat()
    {
        GetComponent<Animator>().SetTrigger("Eat");

    }
}
