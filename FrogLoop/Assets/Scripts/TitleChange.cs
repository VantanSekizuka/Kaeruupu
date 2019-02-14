using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
   public void OnTitleClick()
    {
        SceneManager.LoadScene("Select");
    }

    public void OnStaffClick()
    {
        SceneManager.LoadScene("Staff");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
