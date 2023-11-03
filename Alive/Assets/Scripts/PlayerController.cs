using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float vel = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float avanza = Input.GetAxis("Vertical");
        float gira = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward*Time.deltaTime*vel*avanza);
        transform.Rotate(Vector3.up, Time.deltaTime*40*gira);
    }
}