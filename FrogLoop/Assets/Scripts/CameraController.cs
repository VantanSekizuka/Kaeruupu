﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーを追うカメラ 回転とか接近とかも
public class CameraController : MonoBehaviour {
    GameObject player;
	void Start () {
        player = GameObject.Find("Player");
	}
	
	void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
}
