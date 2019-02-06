using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    Image image;
    Color originColor;
    float timer;

    void Start()
    {
        image = GetComponent<Image>();
        originColor = image.color;
        timer = 0.0f;
    }

    public IEnumerator FadeIn(float time)
    {
        timer = 0.0f;
        while (timer < time) {
            timer += Time.fixedDeltaTime;
            image.color = new Color(originColor.r, originColor.g, originColor.b, timer / time);
            yield return null;
        }
        yield break;
    }

    public IEnumerator FadeOut(float time)
    {
        timer = 0.0f;
        while (timer < time)
        {
            timer += Time.fixedDeltaTime;
            image.color = new Color(originColor.r, originColor.g, originColor.b, 1.0f - timer / time);
            yield return null;
        }
        yield break;
    }
}
