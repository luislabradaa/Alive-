using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linternaController : MonoBehaviour
{
    public Light LuzLinterna;
    public static bool bandera;

    bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        bandera = true;

    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_ANDROID || UNITY_IOS
         if(ControlGeneral.valor){
            if(LuzLinterna.enabled == true){
                LuzLinterna.enabled = false;
                Debug.Log("Esta apagad");
                bandera=false;
            }else if(LuzLinterna.enabled == false){
                LuzLinterna.enabled = true;
                Debug.Log("Esta prendida");
                bandera=true;
            }
        }
        #else
        if(Input.GetButtonDown("Linterna")){
            if(LuzLinterna.enabled == true){
                LuzLinterna.enabled = false;
                Debug.Log("Esta apagad");
                bandera=false;
            }else if(LuzLinterna.enabled == false){
                LuzLinterna.enabled = true;
                Debug.Log("Esta prendida");
                bandera=true;
            }
        }
        #endif
    }
}
