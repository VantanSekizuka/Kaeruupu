using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shita : MonoBehaviour {
    public GameObject Player { get; set; }
    public GameObject Enemy { get; set; }
    LineRenderer lineRenderer;

    [SerializeField] Vector3 offset;
    public float time;

    float timer;
    bool backflag;
    Vector3 dir;
    void Start()
    {
        backflag = false;
        lineRenderer = GetComponent<LineRenderer>();
        Destroy(this.gameObject, time * 2);
        timer = 0.0f;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > time)
        {
            backflag = !backflag;
            timer -= time;
        }
        if (backflag) {
            this.transform.position = dir + (Player.transform.position - dir) * (timer / time);
        }
        else
        {
            this.transform.position = Enemy.transform.position + (Player.transform.position - Enemy.transform.position) * ((time - timer) / time);
            dir = Enemy.transform.position;
        }
        lineRenderer.SetPosition(0, Player.transform.position - transform.position + offset);
    }
}
