using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//タガメ
public class Tagame : IEnemy
{

    [SerializeField]
    private float Tagame_y;

    private bool Tagame_count = true;

    private Transform Tagame_Pos;

    void Start()
    {
        Tagame_Pos=GetComponent<Transform>();
    }
    protected override void FixedUpdate()
    {

        if (Tagame_y > Tagame_Pos.localPosition.y)
        {
            Tagame_count = true;
        }
        else
        {
            Tagame_count = false;
        }

        if (Tagame_count == true)
        {
            transform.Translate(0, Tagame_y, 0);
        }
        if (Tagame_count == false)
        {
            transform.Translate(0, -Tagame_y, 0);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {

    }
}

