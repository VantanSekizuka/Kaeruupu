using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            IPlayerMove.OnGroundFlag = true;
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
