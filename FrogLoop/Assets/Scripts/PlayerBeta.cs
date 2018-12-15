using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オタマジャクシ足つき
public class PlayerBeta : IPlayerMove {

    

    void Start()
    {
        Debug.Log("Start");
    }

    void OnEnable()
    {
        Debug.Log("Enable");
    }

    void FixedUpdate()
    {
       
        if (Input.GetMouseButton(0))
        {
           
            Move();
        }
        //ここでむーぶよびだす
    }

    protected override void Move()
    {
        
        float x = this.transform.position.x;
        
        Vector3 _mousePosittion = Input.mousePosition - new Vector3(Screen.width / 2, 0, 0);
        Debug.Log(x);
        if (x < _mousePosittion.x)
        {
            this.transform.position += new Vector3(0.01f, 0, 0);
           
        }else if(x > _mousePosittion.x)
        {
            this.transform.position -= new Vector3(0.01f, 0, 0);
        }
        
       
        //ここでかく
    }
}
