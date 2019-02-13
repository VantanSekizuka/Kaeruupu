using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwa : MonoBehaviour {

    public void Iwa_Thoucd(){
        var player = GameObject.Find("Player");
        if (player.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
        {
            GameObject.Find("Player").GetComponent<PlayerGamma>().Eat();
            transform.Translate(-1.0f, 0, 0);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
