using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGeneral : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myGameObject;

    public bool isVisible;

    void Start()
    {
        // Activamos el GameObject si isVisible es true
        myGameObject.SetActive(isVisible);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
