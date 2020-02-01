using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float xRotation = 0;

    public float camera_sensitivity;
    private Transform player;

    // Start is called before the first frame update
    private void Awake()
    {
        player = transform.parent; //Assuming the parent is always the playerss
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * camera_sensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * camera_sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
        // rotate the player on the x axis
        //transform.localRotation = Quaternion.Euler(new Vector3(-mouseX, 0, 0));
        //rotate the camera on the y axis
    }
}
