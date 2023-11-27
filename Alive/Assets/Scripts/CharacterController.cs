using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine.UI;
using System;


public class CharacterController : MonoBehaviour
{

    private int vidaPlayer = 100;
    public float speed = 5.0F; //Velocidad de movimiento
    public float rotationSpeed = 100.0F; //Velocidad de rotación
    public AudioSource pasos;
    private bool Hactivo; // Horizontal sonido
    private bool Vactivo; // Vertical sonido
    public bool HasKey;

    private String name;
    public static int score = 0;
    private bool playerInTrigger;

    private Rigidbody playerRb;

    private bool playerHasKey;

    private MongoClient client;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;

    public Slider visualSlider;



    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.6tl1aef.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("Uniry");
        collection = db.GetCollection<BsonDocument>("player");
        name = MenuController.nombreJugador;
        Debug.Log("El nombre es:" + name);
        score = 0;
        // Obtener todos los documentos de la colección "player"
        var sortedDocuments = collection.Find(new BsonDocument())
            .Sort(Builders<BsonDocument>.Sort.Descending("Puntuacion"))
            .ToList();
        // Iterar sobre los documentos e imprimirlos en la consola
        foreach (var document in sortedDocuments)
        {
            Debug.Log(document.ToString());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        vidaPlayer = 50;
        if (other.gameObject.tag == "Key")
        {
            HasKey = true;
            vidaPlayer = 0;
            playerInTrigger = true;
        }

        if (other.gameObject.tag == "point")
        {
            score += 10;
            Puntaje.puntos = score;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "point2")
        {
            score += 20;
            Puntaje.puntos = score;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "point3")
        {
            score += 30;
            Puntaje.puntos = score;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            playerInTrigger = false;
            Destroy(other.gameObject);
            //Scene escenaActual = SceneManager.GetActiveScene();
            //UnityEditor.EditorApplication.isPlaying = false;
            SceneManager.LoadScene("FinalJuego");
            score = 0;
            Puntaje.puntos = score;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Destruimos la escena actual


            // Cargamos la nueva escena
            //SceneManager.LoadScene("FinalJuego");
            //SceneManager.LoadScene("FinalJuego", LoadSceneMode.Single);
            //var document = new BsonDocument { { "Nombre", name }, { "Puntuacion", score } };
            //collection.InsertOne(document);
        }
    }


    void OnGUI()
    {
        if (playerInTrigger)
        {
            string message = "Has encontrado la llave";

            // Set the font size to 30 points
            Font font = Font.CreateDynamicFontFromOSFont("Arial", 30);
            // Assign the font to the GUI skin
            GUI.skin.font = font;

            // Set the text color to red
            GUI.color = Color.red;

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 459, 90), message);
        }
    }

    void Update()
    {

        //vidaVisual.value = vidaPlayer;
        visualSlider.GetComponent<Slider>().value = vidaPlayer;

        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

        //Reproduce sonido de pasos
        if (Input.GetButtonDown("Horizontal"))
        {
            Hactivo = true;
            pasos.Play();
        }
        if (Input.GetButtonDown("Vertical"))
        {
            Vactivo = true;
            pasos.Play();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();
            }

        }
        if (Input.GetButtonUp("Vertical"))
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
            }
        }
    }
}
