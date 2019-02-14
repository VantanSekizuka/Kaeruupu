using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaffManager : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    [SerializeField]
    private float speed = 10;

    float y = -2256;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTitleClick()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (y <= 2245)
        {
            y += speed;

            text.gameObject.transform.localPosition = new Vector3(0, y, 0);
        }
    }
}
