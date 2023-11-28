using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;
using System;


public class PuertaNivel2 : MonoBehaviour
{

    [SerializeField] private float smooth = 2.0f; // Speed of door opening/closing
    [SerializeField] private float doorOpenAngle = 90.0f; // Angle to which the door should open

    private bool isOpen; // Whether the door is open or not
    private bool playerInTrigger; // Whether the player is in the door's trigger collider
    private bool playerHasKey; // Whether the player has the key

    private Vector3 defaultRotation; // Door's default rotation
    private Vector3 openRotation; // Door's rotation when open

    private MongoClient client;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;

    void Start()
    {
        defaultRotation = transform.eulerAngles;
        openRotation = new Vector3(defaultRotation.x, defaultRotation.y + doorOpenAngle, defaultRotation.z);
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.6tl1aef.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("Uniry");
        collection = db.GetCollection<BsonDocument>("player");
    }

    void Update()
    {
        // Only allow opening the door if player has the key and is in the trigger
        if (Input.GetKeyDown(KeyCode.F) && playerInTrigger && playerHasKey)
        {
            var document = new BsonDocument { { "Nombre", CharacterController.name }, { "Puntuacion", CharacterController.score } };
            collection.InsertOne(document);
            SceneManager.LoadScene("PantallaFinal");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnGUI()
    {
        Font font = Font.CreateDynamicFontFromOSFont("Arial", 30);
        // Assign the font to the GUI skin
        GUI.skin.font = font;

        // Set the text color to red
        GUI.color = Color.red;

        if (playerInTrigger)
        {
            string message;

            if (!playerHasKey)
            {
                message = "Neceistas una llave";
            }
            else
            {
                message = "Press 'F' to open the door";
            }

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 400, 459, 90), message);
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