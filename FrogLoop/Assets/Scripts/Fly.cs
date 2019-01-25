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
    [SerializeField]
    private GameObject Shita_Plefab;
    
   public GameObject Shita_GameObject { get; set; }
    private float Fly_x;
    private bool Fly_count=false;
    [SerializeField]
    private float Fly_width;

    public void FlyTouch()
    {
        var player = GameObject.Find("Player");
        if (player.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
        {
            Shita_GameObject = Instantiate(Shita_Plefab);
            Shita_GameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject.Find("Player").GetComponent<PlayerGamma>().Eat();

            Destroy(this.gameObject);
            Debug.Log("yes");
        }
    }
    void Start()
    {
        Fly_x = transform.position.x;
        Fly_y = transform.position.y;
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
