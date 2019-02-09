using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour {

    [SerializeField]
    private GameObject[] MudParticle = new GameObject[4];

    public float speed = 10;

    private ParticleSystem[] Particle = new ParticleSystem[4];
   

    bool move;

	// Use this for initialization
	void Start () {
       for(int i = 0; i < 4; i += 1)
        {
            MudParticle[i].gameObject.SetActive(false);
        }
    }

  
    void MudMove()
    {
        for (int i = 0; i < 4; i += 1)
        {
            MudParticle[i].gameObject.SetActive(true);
            Particle[i] = MudParticle[i].GetComponent<ParticleSystem>();
          
        }

        if(speed >= 0)
        {
            speed -= 0.01f;
        }
        else
        {
            Debug.Log("a");
            for (int i = 0; i < 4; i += 1)
            {
                Particle[i].loop = false;
            }

            move = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            move = true;
        }

        if (move)
        {
            MudMove();
        }

    }
}
