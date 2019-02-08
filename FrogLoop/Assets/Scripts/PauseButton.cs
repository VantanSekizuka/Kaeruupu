using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    [SerializeField]
    private GameObject _menuScreen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PauseButtonPush()
    {
        Time.timeScale = 0;
        _menuScreen.SetActive(true);
    }
    public void ExitButtonPush()
    {
        _menuScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
