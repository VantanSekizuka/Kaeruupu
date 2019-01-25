using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtamaFriends : MonoBehaviour {
    GameObject player;
    Rigidbody2D rigidbody;
    [SerializeField] float maxSpeed;
    [SerializeField] float minLength;
    [SerializeField] float maxLength;
    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        var dir = player.transform.position - transform.position;
        if (dir.sqrMagnitude > minLength * minLength)
        {
            if (dir.sqrMagnitude < maxLength * maxLength)
            rigidbody.AddForce(2 * dir);
        }
        if (rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}
