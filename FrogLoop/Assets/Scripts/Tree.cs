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
        player.transform.position = transform.Find("Entrance").transform.position;
        transform.parent.Find("Inner").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void Exit()
    {
        var player = GameObject.Find("Player");
        Camera.allCameras[0].transform.Rotate(Vector3.forward * -90.0f);
        player.transform.position = transform.Find("Entrance").transform.position;
        transform.parent.Find("Outer").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
