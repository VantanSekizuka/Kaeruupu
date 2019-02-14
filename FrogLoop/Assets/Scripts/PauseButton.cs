using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    [SerializeField]
    private GameObject _menuScreen;
    public AudioClip clip;
    private AudioSource source;
    void Start () {
        source = gameObject.GetComponent<AudioSource>();
    }
	
	
	void Update () {
		
	}
    public void PauseButtonPush()
    {
        source.PlayOneShot(clip);
        Time.timeScale = 0;
        _menuScreen.SetActive(true);
    }
    public void ExitButtonPush()
    {
        _menuScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
