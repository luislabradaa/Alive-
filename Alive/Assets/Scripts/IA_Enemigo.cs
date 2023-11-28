using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Enemigo : MonoBehaviour
{
    public Transform Objetivo;
    public float Velocidad;
    public NavMeshAgent IA;

    public Animation Anim;
    public string animacionCaminar;
    public string animacionAtacar;


    // Update is called once per frame
    void Update()
    {

        if (linternaController.bandera == true)
        {
            IA.speed = Velocidad;
            IA.SetDestination(Objetivo.position);
            //Debug.Log("Entro enemigo");
        }else{
            IA.SetDestination(Vector3.zero);
             //Debug.Log("No Entro enemigo");
        }

        /* if(IA.velocity == Vector3.zero){
             Anim.CrossFade(animacionAtacar);
         }else{
             Anim.CrossFade(animacionCaminar);
         }*/
    }

    /*public void Ataque(){
        Objetivo.GetComponent<Codigo_Salud>().RecibirDaño;
    }*/

}
