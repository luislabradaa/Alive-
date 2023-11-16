using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;

public class DBMongo : MonoBehaviour
{


    private MongoClient client;

    private IMongoDatabase db;

    private IMongoCollection<BsonDocument> collection;

        // Start is called before the first frame update
        void Start()
    {

        client = new MongoClient("mongodb+srv://unity:unity@cluster0.6tl1aef.mongodb.net/?retryWrites=true&w=majority");

        db = client.GetDatabase("Uniry");
        collection = db.GetCollection<BsonDocument>("player");
        Debug.Log("Insertando Score");

        var document = new BsonDocument{{"Name","Gabo"}, {"score","200"}};

        collection.InsertOne(document);


    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
