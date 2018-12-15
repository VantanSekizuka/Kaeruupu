using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵クラスのインタフェース
public abstract class IEnemy : MonoBehaviour
{
    public bool HitingBool=false; 
    protected abstract void OnCollisionEnter2D(Collision2D other); //当たった時
    protected abstract void FixedUpdate(); //日々の動き
}