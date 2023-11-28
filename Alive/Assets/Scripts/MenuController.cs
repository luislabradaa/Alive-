using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class MenuController : MonoBehaviour
{

    public static string nombreJugador;

    public void capturaNombre(String nombre){
        nombreJugador = nombre;
        Debug.Log(nombreJugador);
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterController.score =0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void niveles(){
        if (CharacterController.nivel == 1)
        {
            Nivel1();
        }else if (CharacterController.nivel == 2)
        {
            Nivel2();
        }
    }

     public void Load(){
        SceneManager.LoadScene("Nivel1");
    }

    public void Nivel1(){
         CharacterController.nivel =1;
        SceneManager.LoadScene("Nivel1");
    }

    public void Nivel2(){
        SceneManager.LoadScene("Nivel2"); 
    }

     public void FinJuego(){
        SceneManager.LoadScene("FinalJuego");  //FinalJuego
    }

     public void Menu(){
        SceneManager.LoadScene("MenuAlive");  //FinalJuego
    }

    public void Salir(){
        Application.Quit();
    }

    

}
