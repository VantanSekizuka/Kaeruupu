using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiru : IEnemy{
    protected override void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        throw new System.NotImplementedException();
    }

    private float hiru_x;
    [SerializeField]
    private float hiru_haba;
    [SerializeField]
    private float Speed;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
