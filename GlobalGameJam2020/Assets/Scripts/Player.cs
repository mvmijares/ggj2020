using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public bool keyboard = true;
    private void Awake()
    {
        
    }
    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (keyboard)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right* Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A)){
                transform.Translate(-Vector3.right * Time.deltaTime * speed);
            }
        }
    }
}
