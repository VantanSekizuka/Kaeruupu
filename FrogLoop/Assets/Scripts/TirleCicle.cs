using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TirleCicle : MonoBehaviour {

    [SerializeField]
    private Image Cicle;


	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        Vector3 ciclemove = new Vector3(0, 0, 0);
        ciclemove.z += 0.5f;

        Cicle.transform.Rotate(ciclemove); 

    }
}
