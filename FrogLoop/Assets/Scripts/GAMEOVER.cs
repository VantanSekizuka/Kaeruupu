using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private Image image;

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
    void Start()
    {
        if (GameManager.stageNumber > 0)
        {
            image.sprite = sprites[GameManager.stageNumber - 1];
        }

    }

            // Update is called once per frame
            void Update () {
		
	}
}
