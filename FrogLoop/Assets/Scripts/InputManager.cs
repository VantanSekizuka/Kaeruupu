using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//入力を管理するクラス
public class InputManager : MonoBehaviour {

    static public InputManager inputManager;
    [SerializeField] float tapTime = 0.1f;
    float taptimer;

    void Start () {
        inputManager = this;
        PlayerDrag = false;
	}

    public Vector2 tapPosition { get; private set; }
    public enum TouchState
    {
        FREE,
        PRESSING,
        PUSHED,
        RELEASE
    }
    public TouchState state;
    public bool PlayerDrag { get; set; }
    public bool TapFlag { get; private set; }
    void FixedUpdate()
    {
        state = TouchState.FREE;
        TapFlag = false;
        if (Input.GetMouseButton(0))
        {
            Vector3 screen_point = Input.mousePosition;
            screen_point.z = 10.0f;
            tapPosition = Camera.main.ScreenToWorldPoint(screen_point);
            state = TouchState.PRESSING;
            taptimer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            state = TouchState.PUSHED;
            taptimer = 0.0f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            state = TouchState.RELEASE;
            if (taptimer < tapTime)
            {
                TapFlag = true;
            }
        }
    }
}
