using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linternaController : MonoBehaviour
{
    public Light LuzLinterna;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Linterna")){
            if(LuzLinterna.enabled == true){
                LuzLinterna.enabled = false;
            }else if(LuzLinterna.enabled == false){
                LuzLinterna.enabled = true;
            }
        }
    }
}
