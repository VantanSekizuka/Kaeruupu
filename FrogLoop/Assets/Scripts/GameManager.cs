using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//マネージャ　シーンを管理
public class GameManager : MonoBehaviour {
    
    public static GameManager manager;
    
    public enum SceneState
    {
        FIELD,
        TREE
    }

	void Start () {
        manager = this;
	}
	
	void Update () {
		
	}
    public void ChangeScene(string _afterScene)
    {
        SceneManager.LoadScene(_afterScene);
    }
}
