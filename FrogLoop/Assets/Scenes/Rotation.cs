﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rotation : MonoBehaviour {
    [SerializeField] GameObject center;
    [SerializeField] Sprite[] sprites;
    int index;
    Image name;
    Button button;
    public AudioClip clip;
    private AudioSource source;
    public AudioClip clip2;
    private AudioSource source2;
 
    int move;
    int size;

    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source2 = gameObject.GetComponent<AudioSource>();
       
        index = 0;
        move = 0;
        name = transform.Find("Number").GetComponent<Image>();
        button = transform.Find("Select").GetComponent<Button>();
        size = center.transform.childCount;
        for (int i = 0; i < size; i++)
        {
            var f = ((i * 72 + 270) * Mathf.Deg2Rad);
            center.transform.GetChild(i).localPosition = new Vector3(Mathf.Cos(f), 0, Mathf.Sin(f)) * 10;
            Debug.Log(Mathf.Sin((i * 72 + 270) * Mathf.Deg2Rad));
        }
        name.sprite = sprites[0];
    }

    //ボタン
    public void OnL()
    {
        source2.PlayOneShot(clip2);
        move += -360 / size / 2;
        index = (index + size - 1) % size;
        name.sprite = sprites[index];
        button.interactable = false;
    }
    public void OnR()
    {
        source2.PlayOneShot(clip2);
        move += 360 / size / 2;
        index = (index + 1) % size;
        name.sprite = sprites[index];
        button.interactable = false;
    }

    public void Select()
    {
        source.PlayOneShot(clip);
        GameManager.stageNumber = index;
        if (index > 0)
        {
            SceneManager.LoadScene("Stage" + index.ToString());
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
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
