using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSounds : MonoBehaviour
{
    public AudioSource MovementSound;

    void Awake()
    {
        MovementSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            MovementSound.enabled = true;
        }
        else
        {
            MovementSound.enabled = false;
        }
    }
}
