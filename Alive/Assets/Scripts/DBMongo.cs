using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;

public class DBMongo : MonoBehaviour
{


    private MongoClient client;
    
    private Rigidbody playerRb;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;



    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {

    }

}
