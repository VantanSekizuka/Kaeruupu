using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            IPlayerMove.OnGroundFlag = true;
            if (collider.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
            {
                if (collider.gameObject.GetComponent<PlayerGamma>().JumpingFlag == true)
                {
                    collider.gameObject.GetComponent<PlayerGamma>().JumpingFlag = false;

                    collider.GetComponent<Animator>().SetTrigger("OnGround");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            IPlayerMove.OnGroundFlag = false;
        }
    }
}
