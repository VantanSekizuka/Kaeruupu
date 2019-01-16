using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (transform.name.Contains("Outer")) Enter();
            else Exit();
        }
    }

    void Enter()
    {
        var player = GameObject.Find("Player");
        Camera.allCameras[0].transform.Rotate(Vector3.forward * 90.0f);
        var inner = transform.parent.Find("Inner");
        player.transform.position = inner.Find("Entrance").transform.position;
        inner.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void Exit()
    {
        var player = GameObject.Find("Player");
        Camera.allCameras[0].transform.Rotate(Vector3.forward * -90.0f);
        var outer = transform.parent.Find("Outer");
        player.transform.position = outer.Find("Entrance").transform.position;
        outer.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
