using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ハエ
public class Fly : IEnemy {
    private float Fly_y;
    [SerializeField]
    private float Fly_haba;
    [SerializeField]
    private float Speed;
    private float Fly_height;
   
    private float Fly_x;
    private bool Fly_count=false;
    [SerializeField]
    private float Fly_width;

    void Start()
    {
       
       Fly_y = transform.localPosition.y;
        Fly_x = transform.localPosition.x;
       //Fly_height = Fly_y + Fly_haba/2;

    }

    protected override void FixedUpdate()
    {
        //if(Fly_count==true)
        //{
        //    transform.Translate(0.5f, 0, 0);
        //    Fly_count = false;
        //}
        
        //if (transform.localPosition.y > Fly_height)
        //{
        //    Fly_count = true;
        //}
        //else
        //{
        //    Fly_count = false;
        //}
        
        
        //Debug.Log(Fly_count);
        transform.position = new Vector3(Fly_x+Fly_width*Mathf.Sin(Time.time), Fly_y + Fly_haba * Mathf.Sin(Time.time * Speed), transform.position.z);

    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HitingBool = true;
            Debug.Log(HitingBool);
        }
    }
}
