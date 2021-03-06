﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRoof : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            {
                collider.gameObject.GetComponent<PlayerAlpha>().Jumping = false;
            }
            else if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
            {
                collider.gameObject.GetComponent<PlayerGamma>().JumpingFlag = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            {
                collider.gameObject.GetComponent<PlayerAlpha>().Jumping = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            {
                if (collider.gameObject.GetComponent<PlayerAlpha>().Jumping)
                {
                    return;
                }
            }
            else
            {
                return;
            }
            PushBack(collider);
        }
        if (collider.gameObject.tag.Contains("Friends"))
        {
            PushBack(collider);
        }
    }

    void PushBack(Collider2D collider)
    {
        if (collider.transform.position.y > transform.position.y)
        {
            var mag = (collider.transform.position.y - transform.position.y);
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.down * mag * mag * 100);
        }
    }
}
