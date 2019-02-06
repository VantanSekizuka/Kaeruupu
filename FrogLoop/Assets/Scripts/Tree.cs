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
        yield return StartCoroutine(GameManager.manager.TreeInOut(GameManager.SceneState.TREE));
        Debug.Log("abc");
        var player = GameObject.Find("Player");
        var inner = transform.parent.Find("Inner");
        player.transform.position = inner.Find("Entrance").transform.position;
        inner.gameObject.SetActive(true);
        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeOut(1.0f));
        gameObject.SetActive(false);
        yield break;
    }

    IEnumerator Exit()
    {
        yield return StartCoroutine(GameManager.manager.TreeInOut(GameManager.SceneState.FIELD));
        var player = GameObject.Find("Player");
        var outer = transform.parent.Find("Outer");
        player.transform.position = outer.Find("Entrance").transform.position;
        outer.gameObject.SetActive(true);
        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeOut(1.0f));
        gameObject.SetActive(false);
        yield break;
    }
}
