using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerRoad : MonoBehaviour
{

    float removeOject = 30f;

    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        //mengambil player transform
        Transform playerTf = playerObject.transform;

        //mengecek apakah object sudah melewati player
        if (transform.position.z < playerTf.position.z - removeOject)
        {
            Destroy(gameObject);
        }

    }

}
