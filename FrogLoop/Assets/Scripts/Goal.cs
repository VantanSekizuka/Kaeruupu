﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(GameManager.manager.Goal());
    }
}
