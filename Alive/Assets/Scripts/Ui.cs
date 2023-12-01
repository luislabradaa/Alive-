using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{

    public GameObject botones;

    // Start is called before the first frame update
    void Start()
    {

#if UNITY_ANDROID || UNITY_IOS
        botones.SetActive(true);
#else
             botones.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {

    }
}
