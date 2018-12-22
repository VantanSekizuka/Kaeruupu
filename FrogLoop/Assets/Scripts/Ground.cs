using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
            {
                if (collision.gameObject.GetComponent<PlayerGamma>().JumpingFlag == true)
                {
                    collision.gameObject.GetComponent<PlayerGamma>().JumpingFlag = false;
                }
            }
        }
    }
}
