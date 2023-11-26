using UnityEngine;
using TMPro;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

public class Puntuacion : MonoBehaviour
{
   
    public TextMeshProUGUI textMeshPro;


    private MongoClient client;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;

    private string[] jugadoresCol;





    void Start()
    {
        // Obtener el valor del documento
        string[] jugadores = GetDocumentValue();

        // Actualizar el valor del documento en el componente Text
        string playerNameList = string.Join("\n", jugadores);
        textMeshPro.text = playerNameList;

    }


    private string[] GetDocumentValue()
    {
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
        jugadoresCol = new string[sortedDocuments.Count];
        int i = 0;
        foreach (var document in sortedDocuments)
        {
    
            jugadoresCol[i] = document["Puntuacion"].ToString();
            i++;
        }
        return jugadoresCol;
    }
}
