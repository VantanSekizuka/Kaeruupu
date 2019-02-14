using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour {

    public void ReStart()
    {
        if (GameManager.stageNumber > 0)
        {
            SceneManager.LoadScene("Stage" + GameManager.stageNumber.ToString());
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void selsect()
    {
        SceneManager.LoadScene("Select");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
