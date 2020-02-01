﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Data
    GameManager gm_instance;

    [SerializeField]
    private bool objectInHand = false;

    public float speed = 2f;
    public bool keyboard = true;
    public float pickupDistance;
    public LayerMask objectLayerMask;

    public Transform tipOfHand;
    #endregion
    private void Awake()
    {
        gm_instance = GameManager.instance;   
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        PlayerInput();
        ObjectPickup();
    }

    private void ObjectPickup()
    {
        if (keyboard)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!objectInHand)
                {
                    RaycastHit hit;

                    Transform cam_transform = gm_instance.GetPlayerCamera().transform;

                    if (Physics.Raycast(cam_transform.position, cam_transform.forward, out hit, pickupDistance, objectLayerMask))
                    {
                        objectInHand = true;
                        CreateObjectClone(hit.transform);
                        Debug.Log("Raycast has hit object");
                    }

                }
            }
        }
    }

    private void CreateObjectClone(Transform reference)
    {

        Transform clone = Instantiate(reference, tipOfHand.position, reference.rotation);
        clone.parent = tipOfHand;
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
