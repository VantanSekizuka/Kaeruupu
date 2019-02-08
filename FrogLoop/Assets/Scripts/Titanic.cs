using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titanic : MonoBehaviour
{

    Vector3 titanic = Vector3.zero;
    public float speed = 0.001f;

    // Use this for initialization
    void Start()
    {
        titanic = this.gameObject.transform.position;
    }

    //protected override void FixedUpdate()
    //{
    //    if (IPlayerMove.InWaterFlag)
    //    {
    //        titanic.y += speed;
    //        this.gameObject.transform.position = titanic;
    //    }
    //}

    void Update()
    {

    }
}

