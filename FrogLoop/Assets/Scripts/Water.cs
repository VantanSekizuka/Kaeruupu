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
            other.GetComponent<Rigidbody2D>().drag = 3.0f;
            if (other.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
            {
                Debug.Log("aaa");
                other.GetComponent<Rigidbody2D>().gravityScale = -0.2f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IPlayerMove.InWaterFlag = false;
            other.GetComponent<Rigidbody2D>().drag = 0.0f;
            if (other.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
            {
                Debug.Log("bbb");
                other.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
        }
    }
}
