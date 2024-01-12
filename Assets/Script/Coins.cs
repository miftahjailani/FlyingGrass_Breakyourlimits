using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coins : MonoBehaviour
{
    float removeOject = 5f;
    public int pointValue;

    private GameObject playerObject;


    private bool hasBeenCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);

        //mengambil player transform
        Transform playerTf = playerObject.transform;

        //mengecek apakah object sudah melewati player
        if (transform.position.z < playerTf.position.z - removeOject)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasBeenCollected)
        {
            //checking the flag untuk menghindari 2 kali pengambilan
            hasBeenCollected = true;


            MainManager.inst.AddScore(pointValue);
            
            // Destroy coins
            Destroy(gameObject);

        }
    }


}
