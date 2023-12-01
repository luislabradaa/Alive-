using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_PersonajeSecundario : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    
    void OnTriggerStay(Collider other)
    {
        // Check if the other collider is the player collider
        if (other.gameObject.CompareTag("Player"))
        {
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);
        }
    }
}
    

    


