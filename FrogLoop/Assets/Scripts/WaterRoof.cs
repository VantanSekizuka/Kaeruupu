using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRoof : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            {
                collider.gameObject.GetComponent<PlayerAlpha>().JumpFlag = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.gameObject.GetComponent<PlayerStatus>().status == PlayerStatus.Status.ALPHA)
            {
                collider.gameObject.GetComponent<PlayerAlpha>().JumpFlag = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Contains("Player"))
        {
            if (collider.transform.position.y > transform.position.y)
            {
                //collider.transform.Translate(Vector3.up * (transform.position.y - collider.transform.position.y) * 0.9f);
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (transform.position.y - collider.transform.position.y) * 90f);
            }
        }
    }
}
