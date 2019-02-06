using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵クラスのインタフェース
public abstract class IEnemy : MonoBehaviour
{
    public bool HitingBool=false; 
    protected abstract void OnCollisionEnter2D(Collision2D other); //当たった時
    protected abstract void FixedUpdate(); //日々の動き
    protected float shitaNobashi()
    {
        var player = GameObject.Find("Player");
        if (player.GetComponent<PlayerStatus>().status == PlayerStatus.Status.GAMMA)
        {
            GameObject prefab = (GameObject)Resources.Load("Prefabs/Shita");
            var shita = Instantiate(prefab);
            shita.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            shita.GetComponent<Shita>().Player = player.gameObject;
            shita.GetComponent<Shita>().Enemy = this.gameObject;
            GameObject.Find("Player").GetComponent<PlayerGamma>().Eat();
            return shita.GetComponent<Shita>().time;
        }
        return 0.0f;
    }
}