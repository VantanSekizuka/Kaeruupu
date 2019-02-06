using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//マネージャ　シーンを管理
public class GameManager : MonoBehaviour {
    
    public static GameManager manager;
    [SerializeField] int frameCount;
    GameObject effect;
    
    public enum SceneState
    {
        FIELD,
        TREE
    }

	void Start () {
        manager = this;
	}
	
	void Update () {
		
	}

    public IEnumerator TreeInOut(SceneState state)
    {
        Time.timeScale = 0.0f;

        yield return StartCoroutine(Effect.effect.transform.Find("Fade").GetComponent<Fade>().FadeIn(1.0f));

        Vector3 cameraRotate = Vector3.zero;
        switch (state)
        {
            case SceneState.FIELD :
                cameraRotate = Vector3.forward * -90.0f;
                break;

            case SceneState.TREE:
                cameraRotate = Vector3.forward * 90.0f;
                break;
        }
        cameraRotate /= frameCount;
        for(int i = 0; i < frameCount; i++)
        {
            Camera.allCameras[0].transform.Rotate(cameraRotate);
            //yield return new WaitForSecondsRealtime(rotateTime / frameCount);
            yield return null;
        }

        Time.timeScale = 1.0f;

        yield break;
    }
}
