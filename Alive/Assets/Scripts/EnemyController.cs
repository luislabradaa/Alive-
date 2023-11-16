using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed =  3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(player.transform.position - transform.position * speed);
    }




}
