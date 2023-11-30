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

    public bool HasKeycharacter;

    public static bool HasKeycharacter2;

    public static int nivel;

    public static String name;
    public static int score = 0;
    private bool playerInTrigger;

    private Rigidbody playerRb;

    private bool playerHasKey;

    private MongoClient client;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;

    public Slider visualSlider;

    public Joystick joystick;

    private float y;

    private float x;



    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        client = new MongoClient("mongodb+srv://unity:unity@cluster0.6tl1aef.mongodb.net/?retryWrites=true&w=majority");
        db = client.GetDatabase("Uniry");
        collection = db.GetCollection<BsonDocument>("player");
        name = MenuController.nombreJugador;
        Debug.Log("El nombre es:" + name);
        HasKey = false;
        HasKeycharacter = false;
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
            nivel = 1;
            playerInTrigger = true;
            playerHasKey = true;
        }

        if (other.gameObject.tag == "Key2")
        {
            HasKeycharacter =true;
            HasKeycharacter2 = true;
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

        if (other.gameObject.tag == "level2")
        {
            SceneManager.LoadScene("Nivel2");
        }

        //Condición gameover
        if (other.gameObject.tag == "Enemy")
        {

            if (vidaPlayer == 50)
            {
                vidaPlayer = 0;
            }
            else
            {
                vidaPlayer = 50;
            }

            if (vidaPlayer == 0)
            {
                Debug.Log("Muerte maniqui");
                SceneManager.LoadScene("FinalJuego");
                score = 0;
                Puntaje.puntos = score;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }

        if (other.gameObject.tag == "Enemy1")
        {

            if (vidaPlayer == 100 || vidaPlayer == 50)
            {
                vidaPlayer = 0;
            }

            if (vidaPlayer == 0)
            {
                Debug.Log("Muerte payaso");
                SceneManager.LoadScene("FinalJuego");
                score = 0;
                Puntaje.puntos = score;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {


        if (other.gameObject.tag == "Key2")
        {
            playerInTrigger = false;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Key")
        {
            playerInTrigger = false;
            Destroy(other.gameObject);
            nivel = nivel + 1;


            //Scene escenaActual = SceneManager.GetActiveScene();
            //UnityEditor.EditorApplication.isPlaying = false;
            //score = 0;
            //Puntaje.puntos = score;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
            //SceneManager.LoadScene("Nivel2");
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

            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 400, 459, 90), message);
        }
    }

    void Update()
    {

#if UNITY_ANDROID || UNITY_IOS
        y = joystick.Horizontal;
        x = joystick.Vertical;

        transform.Translate(0, 0, x * speed * Time.deltaTime);
        transform.Rotate(0, y * rotationSpeed * Time.deltaTime, 0);

        //Reproduce sonido de pasos
        if (y != 0)
        {
            Hactivo = true;
            pasos.Play();
        }
        if (x != 0)
        {
            Vactivo = true;
            pasos.Play();
        }

        if (y != 0)
        {
            Hactivo = false;
            if (Vactivo == false)
            {
                pasos.Pause();
            }

        }
        if (x != 0)
        {
            Vactivo = false;
            if (Hactivo == false)
            {
                pasos.Pause();
            }
        }
#else
            
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
#endif

        //vidaVisual.value = vidaPlayer;
        visualSlider.GetComponent<Slider>().value = vidaPlayer;

    }
}
