using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFlash : MonoBehaviour {

    Image image;
    Text text;

	// Use this for initialization
	void Start () {
       image = GetComponent<Image>();
       text = transform.Find("Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        image.color = new Color(1, 1, 1, Mathf.PingPong(Time.time,1.0f)*0.8f + 0.1f);
        text.color = new Color(0, 0, 0, Mathf.PingPong(Time.time, 1.0f) *0.9f + 0.1f);
    }
}
