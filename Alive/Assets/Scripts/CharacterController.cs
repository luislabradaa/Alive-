using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0F; //Velocidad de movimiento
    public float rotationSpeed = 200.0F; //Velocidad de rotación
    public AudioSource pasos;
    private bool Hactivo; // Horizontal sonido
    private bool Vactivo; // Vertical sonido

    void Update() {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime , 0);

        //Reproduce sonido de pasos
        if(Input.GetButtonDown("Horizontal")){
            Hactivo = true;
            pasos.Play();
        }
        if(Input.GetButtonDown("Vertical")){
            Vactivo = true;
            pasos.Play();
        }

        if(Input.GetButtonUp("Horizontal")){
            Hactivo = false;
            if(Vactivo == false){
                pasos.Pause();
            }
            
        }
        if(Input.GetButtonUp("Vertical")){
            Vactivo = false;
            if(Hactivo == false){
                pasos.Pause();
            }
        }
    }
}
