using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//タガメ
public class Tagame : IEnemy
{
    private float Tagame_y;
    [SerializeField]
    private float Tagame_haba;
    [SerializeField]
    private float  Speed;

    [SerializeField]
    GameObject Kaelu;

    void Start()
    {
        Kaelu = GameObject.Find("Player");
        
        Tagame_y = transform.localPosition.y;
    }
    protected override void FixedUpdate()
    {
        //time += Time.deltaTime;
        //if (time > 1)
        //{
        //    if (Tagame_y > Tagame_Pos.localPosition.y)
        //    {
        //        Tagame_count = true;
        //        Debug.Log("ながぬま");
        //    }
        //    else
        //    {
        //        Tagame_count = false;
        //        Debug.Log("こばやし");
        //    }
        //    time = 0;
        //}
        //Debug.Log(time);
        //if (Tagame_count == true)
        //{
        //    transform.Translate(0, Tagame_Speed, 0);
        //}
        //if (Tagame_count == false)
        //{
        //    transform.Translate(0, -Tagame_Speed, 0);
        //}
       
        transform.position = new Vector3(transform.position.x, Tagame_y+Tagame_haba  * Mathf.Sin(Time.time * Speed), transform.position.z);
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HitingBool = true;
            Debug.Log(HitingBool);
        }
    }
}

