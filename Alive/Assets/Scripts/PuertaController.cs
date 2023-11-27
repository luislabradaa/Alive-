using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{
    [SerializeField] private float smooth = 2.0f; // Speed of door opening/closing
    [SerializeField] private float doorOpenAngle = 90.0f; // Angle to which the door should open

    private bool isOpen; // Whether the door is open or not
    private bool playerInTrigger; // Whether the player is in the door's trigger collider
    private bool playerHasKey; // Whether the player has the key

    private Vector3 defaultRotation; // Door's default rotation
    private Vector3 openRotation; // Door's rotation when open

    void Start()
    {
        defaultRotation = transform.eulerAngles;
        openRotation = new Vector3(defaultRotation.x, defaultRotation.y + doorOpenAngle, defaultRotation.z);
    }

    void Update()
    {
        if (isOpen)
        {
            // Smoothly rotate door towards open position
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRotation, Time.deltaTime * smooth);
        }
        else
        {
            // Smoothly rotate door towards closed position
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRotation, Time.deltaTime * smooth);
        }

        // Only allow opening the door if player has the key and is in the trigger
        if (Input.GetKeyDown(KeyCode.F) && playerInTrigger && playerHasKey)
        {
            isOpen = !isOpen;
        }
    }

    void OnGUI()
    {
        if (playerInTrigger)
        {
            string message = "Press 'F' to open the door";

            if (!playerHasKey)
            {
                message = "Neceistas una llave";
            }

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), message);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = true;
            playerHasKey = other.gameObject.GetComponent<CharacterController>().HasKey; // Assuming PlayerController has a HasKey property
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}