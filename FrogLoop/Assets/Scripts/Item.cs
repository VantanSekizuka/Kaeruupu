using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変化する様子を書く
public class Item : MonoBehaviour {

    [SerializeField] PlayerStatus.Status changeStatus;
    
    //プレイヤーだったらPlayerStatusのChangeをよぼう
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerStatus>().Changed(changeStatus);
            Destroy(transform.gameObject);
        }
    }
}
