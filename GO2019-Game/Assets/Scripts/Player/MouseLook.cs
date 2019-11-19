using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseSense = 50f;
    public Transform playerBody;
    float xRotation = 0f;
    float mouseX = 0f;
    float mouseY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float sensitivity = mouseSense * GameManager.mouseSensitivity;
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        if(!GameManager.invertedY){
            xRotation -= mouseY;
        } else{
            xRotation += mouseY;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);        
    }
}
