using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Image image;

    [SerializeField]
    private Text text;

    private string StageText;
    private string ClearText;

	// Use this for initialization
	void Start () {
        StageText = "次はステージ(o･∇･o)";
        ClearText = "ステージクリア(o･∇･o)";
        text.text = StageText;
	}
	
    public void OnNextClick()
    {
        
    }

    public void OnSelectClick()
    {
        SceneManager.LoadScene("Select");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
