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
    private Button NextButton;


    [SerializeField]
    private Text text;

    private string StageText;
    private string ClearText;
    

	// Use this for initialization
	void Start () {
        StageText = "次はステージ"+ (1+GameManager.stageNumber).ToString();
        ClearText = "ステージクリア(o･∇･o)";
        image.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(true);
        if (GameManager.stageNumber < 4)
        {
            text.text = StageText;
            image.sprite = sprites[GameManager.stageNumber];
            image.gameObject.SetActive(true); 

        }
        else
        {
            text.text = ClearText;
            NextButton.gameObject.SetActive(false);
        }



	}
	
    public void OnNextClick()
    {
        SceneManager.LoadScene("Stage"+(1+GameManager.stageNumber).ToString());
    }

    public void OnSelectClick()
    {
        SceneManager.LoadScene("Select");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
