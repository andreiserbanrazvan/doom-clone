using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 1.5f;
    public float smoothing = 1.5f;


    private float xMousePos;
    private float smoothMousePos;

    private float currentLookingPos;
   
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    private void MovePlayer()
    {
        currentLookingPos += smoothMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos,transform.up);
    }

    private void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothMousePos = Mathf.Lerp(smoothMousePos, xMousePos, 1f / smoothing);
    }

    private void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }
}
