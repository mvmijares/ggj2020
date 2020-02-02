using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Data
    [SerializeField]
    GameManager gm_instance;
    Rigidbody rb;
    [SerializeField]
    private bool objectInHand = false;

    public float speed = 2f;
    public bool keyboard = true;
    public float pickupDistance;
    public LayerMask objectLayerMask;

    public Transform tipOfHand;

    Transform carryObject;
    public float throwPower;

    private Vector3 inputVector;
    private float inputX;
    private float inputZ;

    #endregion
    private void Start()
    {
        gm_instance = GameManager.instance;

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerInput();
        ObjectPickup();

        
    }
    private void FixedUpdate()
    {
        PlayerMovement();
        Physics.IgnoreLayerCollision(9, 8);
    }
    private void ObjectPickup()
    {
        Transform cam_transform = gm_instance.GetPlayerCamera().transform;

        if (keyboard)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!objectInHand)
                {
                    RaycastHit hit;

                    if (Physics.Raycast(cam_transform.position, cam_transform.forward, out hit, pickupDistance, objectLayerMask))
                    {
                        if (hit.transform.GetComponent<Item>().itemUsed)
                            return;

                        objectInHand = true;
                        CreateObjectClone(hit.transform);
                        if (hit.transform.GetComponent<Item>().shoppingCartItem)
                        {
                            gm_instance.GetShoppingCart().RemoveShoppingCartItem();
                        }
                        Destroy(hit.transform.gameObject);
                    }
                }
                else
                {
                    objectInHand = false;
                    carryObject.SetParent(null);
                    
                    carryObject.GetComponent<Item>().FreezeRigidbody(false);
                    carryObject.GetComponent<Item>().ThrowObject(cam_transform.forward, throwPower);

                }
            }
        }
    }

    private void CreateObjectClone(Transform reference)
    {

        Transform clone = Instantiate(reference, tipOfHand.position, reference.rotation);
        carryObject = clone;
        if (clone.GetComponent<Item>()) 
        {
            clone.GetComponent<Item>().FreezeRigidbody(true);
        }
        clone.parent = tipOfHand;

    }

    private void PlayerInput()
    {
        if (keyboard)
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * 10, 0, Input.GetAxisRaw("Vertical") * 10);

            //if (Input.GetKey(KeyCode.W))
            //{
            //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //}
            //if (Input.GetKey(KeyCode.S))
            //{
            //    transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    transform.Translate(Vector3.right* Time.deltaTime * speed);
            //}
            //if (Input.GetKey(KeyCode.A)){
            //    transform.Translate(-Vector3.right * Time.deltaTime * speed);
            //}
        }
    }

    private void PlayerMovement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        rb.velocity = (forward * inputVector.z) + (right * inputVector.x);

    }
}