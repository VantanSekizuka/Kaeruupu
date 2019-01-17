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
            //if (other.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            //{
                other.GetComponent<Rigidbody2D>().drag = 3.0f;
            //}
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IPlayerMove.InWaterFlag = false;
            //if (other.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            //{
                other.GetComponent<Rigidbody2D>().drag = 0.0f;
            //}
        }
    }
}
