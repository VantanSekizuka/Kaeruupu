using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
