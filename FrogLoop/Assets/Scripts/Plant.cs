using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {
    [SerializeField] int clearCount;
    [SerializeField] float clearPushBack;
    [SerializeField] float power;
	void Start () {
		
	}
	
	void Update () {
        Debug.Log(PlayerAlpha.FriendCount);
	}

    void OnTriggerStay2D(Collider2D collider)
    {
        float per = 1.0f;
        if (PlayerAlpha.FriendCount >= clearCount)
        {
            per = clearPushBack;
        }
        if (collider.gameObject.tag.Contains("Player") || collider.gameObject.tag.Contains("Friends"))
        {
            PushBack(collider, per);
        }
    }

    void PushBack(Collider2D collider, float per)
    {
        if (collider.transform.position.y > transform.position.y)
        {
            var mag = 1.0f - (collider.transform.position.y - transform.position.y) / 10.0f;
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * mag * power * per);
            Debug.Log(mag);
        }
    }
}
