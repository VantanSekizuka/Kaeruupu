using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iwa : MonoBehaviour {

    public void Iwa_Thoucd(){
        var player = GameObject.Find("Player");
        if (player.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
        {
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Shita");
            var shita = Instantiate(prefab);
            shita.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            shita.GetComponent<Shita>().Player = player.gameObject;
            shita.GetComponent<Shita>().Enemy = this.gameObject;
            GameObject.Find("Player").GetComponent<PlayerGamma>().Eat();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(150.0f, 0));
        }
    }
}
