using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoad : MonoBehaviour
{

    public Transform spawnRoad_pos;
    public GameObject prefabRoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn_Road()
    {
        Instantiate(prefabRoad, spawnRoad_pos.position, Quaternion.identity);
        spawnRoad_pos.position = new Vector3(spawnRoad_pos.position.x, spawnRoad_pos.position.y, spawnRoad_pos.position.z + 50f);
    }


}
