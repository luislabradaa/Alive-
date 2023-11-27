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

    public int vidaPlayer = 100;
    public Slider vidaVisual;
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

    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.6tl1aef.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("Uniry");
        collection = db.GetCollection<BsonDocument>("player");
        name = MenuController.nombreJugador;
        Debug.Log("El nombre es:" + name);
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
        if (other.gameObject.tag == "Key")
        {
            HasKey = true;
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

        //Condición gameover
        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene("MenuAlive");
        }
        //Condición gana partida
        if (other.gameObject.tag == "Salida"){
            SceneManager.LoadScene("MenuAlive");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            playerInTrigger = false;
            Destroy(other.gameObject);
            SceneManager.LoadScene("FinalJuego", LoadSceneMode.Single);
            //var document = new BsonDocument { { "Nombre", name }, { "Puntuacion", score } };
            //collection.InsertOne(document);
        }
    }


    void OnGUI()
    {
        if (playerInTrigger)
        {
            string message = "Has encontrado la llave";

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), message);
        }
    }

    void Update()
    {

        //vidaVisual.value = vidaPlayer;

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
