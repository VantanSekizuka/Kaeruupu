using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤー親クラス
public abstract class IPlayerMove : MonoBehaviour {

    void Awake()
    {
        InWaterFlag = false; //ステージ構成による
    }

    public static bool InWaterFlag { get; set; } //水に入っているか
    public static bool OnGroundFlag { get; set; } //地面上かどうか
    
    public void PlayerDirection()
    {
        if (Input.GetMouseButton(0))
        {
            if (this.transform.position.x < InputManager.inputManager.tapPosition.x)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    protected abstract void Move(); //動き フィックスアップデートでよぼう
}
