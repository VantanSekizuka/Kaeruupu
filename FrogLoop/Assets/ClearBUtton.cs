﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBUtton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        GameManager.manager.ChangeScene("Clear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
