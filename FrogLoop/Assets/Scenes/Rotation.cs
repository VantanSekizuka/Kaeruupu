using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour {
    [SerializeField] GameObject center;
    [SerializeField] Sprite[] sprites;
    int index;
    Image name;
    Button button;
    int move;

    void Start()
    {
        index = 0;
        move = 0;
        name = transform.Find("Number").GetComponent<Image>();
        button = transform.Find("Select").GetComponent<Button>();
    }

    //ボタン
    public void OnL()
    {
        move += -45;
        index = (index + 3) % 4;
        name.sprite = sprites[index];
        button.interactable = false;
    }
    public void OnR()
    {
        move += 45;
        index = (index + 1) % 4;
        name.sprite = sprites[index];
        button.interactable = false;
    }

    public void Select()
    {
        Debug.Log("Load Stage" + (index+1));
    }
   
	void Update ()
    {
        if (move > 0)
        {
            center.transform.Rotate(Vector3.up*2);
            move--;
        }else if(move < 0)
        {
            center.transform.Rotate(Vector3.down*2);
            move++;
        }
        else
        {
            button.interactable = true;
        }
    }
   
   
    
   
}
