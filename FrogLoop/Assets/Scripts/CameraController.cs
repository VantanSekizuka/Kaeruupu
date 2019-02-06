using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーを追うカメラ 回転とか接近とかも
public class CameraController : MonoBehaviour {
    public bool Treeflag { get; set; }
    GameObject player;
    [SerializeField] int frameCount = 90;

    void Start () {
        Treeflag = false;
        player = GameObject.Find("Player");
	}
	
	void Update () {
        if (Treeflag)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
	}

    public IEnumerator CameraRotate(Vector3 goalRotate, Vector3 startPosition, Vector3 goalPosition)
    {
        transform.position = new Vector3(startPosition.x, player.transform.position.y, transform.position.z);
        goalRotate /= frameCount;
        //transform.position = new Vector3(goalPosition.x, goalPosition.y, transform.position.z);
        float move_x = (goalPosition.x - transform.position.x) / frameCount;
        for (int i = 0; i < frameCount; i++)
        {
            transform.Rotate(goalRotate);
            transform.position += Vector3.right * move_x;
            //yield return new WaitForSecondsRealtime(rotateTime / frameCount);
            yield return null;
        }
        yield break;
    }
}
