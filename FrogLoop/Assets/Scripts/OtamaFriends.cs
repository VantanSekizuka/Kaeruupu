using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtamaFriends : MonoBehaviour {
    GameObject player;
    Rigidbody2D rigidbody;
    [SerializeField] float maxSpeed;
    [SerializeField] float minLength;
    [SerializeField] float maxLength;
    bool moveFlag;
    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetBool("IfMove", true);
        moveFlag = false;
    }
    void FixedUpdate()
    {
        bool prevFlag = moveFlag;
        var dir = player.transform.position - transform.position;
        if (dir.sqrMagnitude < maxLength * maxLength)
        {
            if (dir.sqrMagnitude > minLength * minLength) rigidbody.AddForce(2 * dir);
            moveFlag = true;
        }
        else
        {
            moveFlag = false;
        }
        if (moveFlag != prevFlag)
        {
            PlayerAlpha.FriendCount += (moveFlag) ? 1 : -1;
        }
        if (rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
