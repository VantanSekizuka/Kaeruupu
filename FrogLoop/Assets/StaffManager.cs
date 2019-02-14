using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StaffManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Cloud;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private Image image;

    [SerializeField]
    private Image Fade;

    [SerializeField]
    private int speed;

    [SerializeField]
    private float CloudSpeed;

    int y = -2256;

    float cloud_x = -880;

    float color_a = 0;

    float fade_a = 0;


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
        cloud_x += CloudSpeed;
        Cloud.gameObject.transform.localPosition = new Vector3(cloud_x, 149, 0);

        image.color = new Color(1, 1, 1, color_a);
        Fade.color = new Color(0, 0, 0, fade_a);
    

       if(color_a < 1.5)
        {
            color_a += 0.01f;
        }else if (y <= 2245)
        {
            y += speed;

            text.gameObject.transform.localPosition = new Vector3(0, y, 0);
        }
        else if(fade_a < 1)
        {
            fade_a += 0.01f;
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
       
    }
}
