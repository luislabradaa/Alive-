using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Load(){
        SceneManager.LoadScene("Nivel1");
    }

    public void Nivel1(){
        SceneManager.LoadScene("Nivel1");
    }

    public void Nivel2(){
        SceneManager.LoadScene("Nivel2"); 
    }

     public void FinJuego(){
        SceneManager.LoadScene("FinalJuego");  //FinalJuego
    }

    public void Salir(){
        Application.Quit();
    }

}
