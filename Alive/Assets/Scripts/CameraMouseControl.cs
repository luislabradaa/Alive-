using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseControl : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensibilidad del mouse
    public Transform target; //Objeto a seguir

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float minXRotation = -70f; // Minima rotación en x
        float maxXRotation = 30f;  // Maxima rotación en x
        float minYRotation = -70f; // Minima rotación en y
        float maxYRotation = 70f;  // Maxima rotación en y


        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);


        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, minXRotation, maxXRotation);


        rotationY += mouseX * sensitivity;
        rotationY = Mathf.Clamp(rotationY, minYRotation, maxYRotation);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
