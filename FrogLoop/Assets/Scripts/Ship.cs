using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    Rigidbody2D _rb;
    [SerializeField] int clearCount;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    bool changedFlag;
    void Update()
    {
        var prevFlag = changedFlag;
        changedFlag = PlayerAlpha.FriendCount >= clearCount;
        if (!prevFlag && changedFlag)
        {
            _rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
