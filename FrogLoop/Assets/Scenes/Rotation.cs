using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour {
    //回転の中心にあるキューブ
    public GameObject manaka;
    //回転中の処理関係
    public GameObject parent;
    Vector3 move = Vector3.zero;
    public float l = 0;
    //ボタンの処理
    private bool a=false;
    private bool b = false;

    //ボタン
    public void OnL()
    {
       move.z =90f;
       manaka.transform.Rotate(move);
    }
    public void OnR()
    {
        
    }
   
	void Update ()
    {

        transform.position = parent.transform.position;
    }
   
   
    
   
}
