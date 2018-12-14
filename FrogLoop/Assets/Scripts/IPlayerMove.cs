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

    protected abstract void Move(); //動き フィックスアップデートでよぼう
}
