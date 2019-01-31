using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish :  IEnemy {

    public float speed = 0.001f;
    Vector3 fish = Vector3.zero;

   

	// Use this for initialization
	void Start () {
        fish = this.gameObject.transform.position;
	}


    protected override void FixedUpdate()
    {
        if (IPlayerMove.InWaterFlag)
        {
            fish.x += speed;
            this.gameObject.transform.position = fish;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          
            Debug.Log("こがたん");
        }
    }

}
