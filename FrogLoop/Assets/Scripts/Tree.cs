using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (transform.name.Contains("Outer")) StartCoroutine(Enter());
            else StartCoroutine(Exit());
        }
    }

    IEnumerator Enter()
    {
        Time.timeScale = 0.0f;
        var player = GameObject.Find("Player");
        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeIn(1.0f));

        GameObject.Find("BG").transform.position = new Vector3(0,0, -5);

        var inner = transform.parent.Find("Inner");
        player.transform.position = inner.Find("Entrance").transform.position;
        inner.gameObject.SetActive(true);

        var camera = Camera.allCameras[0].GetComponent<CameraController>();
        camera.Treeflag = true;
        yield return StartCoroutine(camera.CameraRotate(Vector3.forward * 90.0f, player.transform.position ,transform.parent.position));

        Time.timeScale = 1.0f;

        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeOut(1.0f));
        gameObject.SetActive(false);
        yield break;
    }

    IEnumerator Exit()
    {
        Time.timeScale = 0.0f;
        var player = GameObject.Find("Player");
        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeIn(1.0f));

        GameObject.Find("BG").transform.position = new Vector3(0, 0, -1);

        var outer = transform.parent.Find("Outer");
        outer.gameObject.SetActive(true);

        var camera = Camera.allCameras[0].GetComponent<CameraController>();
        yield return StartCoroutine(camera.CameraRotate(Vector3.forward * -90.0f, camera.transform.position, player.transform.position));
        player.transform.position = outer.Find("Entrance").transform.position;
        camera.Treeflag = false;

        Time.timeScale = 1.0f;

        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeOut(1.0f));
        gameObject.SetActive(false);
        yield break;
    }
}
