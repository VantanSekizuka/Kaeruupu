using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour {
    public void Down()
    {
        InputManager.inputManager.PlayerDrag = true;
    }
    public void Up()
    {
        InputManager.inputManager.PlayerDrag = false;
    }
}
