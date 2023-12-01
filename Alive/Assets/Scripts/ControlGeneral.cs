using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGeneral : MonoBehaviour
{
    // Start is called before the first frame updatepublic static bool bandera;

    public bool isEnabled;

    public static bool valor;
    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true;
        valor = isEnabled;
    }

    public void prender()
    {
        isEnabled = !isEnabled;
        valor = isEnabled;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
