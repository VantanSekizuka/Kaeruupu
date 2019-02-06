using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {
    public static Effect effect;
    void Start()
    {
        effect = this;
    }
}
