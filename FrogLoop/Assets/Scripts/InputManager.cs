using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//入力を管理するクラス
public class InputManager : MonoBehaviour {

    static public InputManager inputManager;

    void Start () {
        inputManager = this;
	}

    public Vector2 tapPosition { get; private set; }

    void FixedUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screen_point = Input.mousePosition;
            screen_point.z = 10.0f;
            tapPosition = Camera.main.ScreenToWorldPoint(screen_point);
            Debug.Log(tapPosition);
        }
    }
}
