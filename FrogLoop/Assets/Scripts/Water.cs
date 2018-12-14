using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//水に入った瞬間と出た瞬間を伝えるクラス
public class Water : MonoBehaviour {

    //プレイヤーが出たり入ったりしたらIplayerMoveのChangeをよぼう
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IPlayerMove.InWaterFlag = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IPlayerMove.InWaterFlag = false;
        }
    }
}
