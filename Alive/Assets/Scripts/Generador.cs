using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] monedasPrefabs;
    private float yPosition = 0.1f;

     private void Start()
    {
        GenerarMoneda();
        // Llamar al método GenerarMoneda cada 10 segundos.
        InvokeRepeating("GenerarMoneda", 0f, 3f);
    }

    private void GenerarMoneda()
    {
        int indexMoneda = Random.Range(0, monedasPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(220, 260), yPosition, Random.Range(380, 313));
        Instantiate(monedasPrefabs[indexMoneda], spawnPosition, monedasPrefabs[indexMoneda].transform.rotation);
    }
    

}
