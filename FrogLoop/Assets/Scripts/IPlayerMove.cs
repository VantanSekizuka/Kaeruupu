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

    protected abstract void Move(); //動き フィックスアップデートでよぼう
}
