using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private PlayerController pControlller;
    // Start is called before the first frame update
    void Start()
    {
       pControlller = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            pControlller.enabled = false;
            pControlller.GameOver();

        }
    }
}
