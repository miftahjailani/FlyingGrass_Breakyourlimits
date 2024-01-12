using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    public GameObject[] coinsPrefab;
    private List<int> usedSpawnPoints = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        // Spawn obstacles
        for (int i = 0; i < 3; i++)
        {
            SpawnObstacle();
        }
        // Spawn Coins
        for (int i = 0; i < 5; i++)
        {
            SpawnCoins();
        }


    }

     // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObstacle()
    {
        // Memilih random point untuk spawn obstacle
        int obstacleSpawnIndex = GetRandomSpawnIndex();
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex);

        // Spawn obstacle di posisi yang sudah di random
        GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        // merandom ukuran scale pada y pada obstacle yang akan spawn
        float scaleFactor = Random.Range(3.0f, 8.0f); 
        spawnedObstacle.transform.localScale = new Vector3(3.0f, scaleFactor, 0.3f);

        //memasukkan spawn point kedalam list
        usedSpawnPoints.Add(obstacleSpawnIndex);

    }

    public void SpawnCoins()
    {
        // Memilih random point untuk spawn obstacle
        int coinsSpawnIndex = GetRandomSpawnIndex();
        Transform spawnPoint = transform.GetChild(coinsSpawnIndex);

        // Spawn obstacle di posisi yang sudah di random
        int jenisCoins = Random.Range(0, coinsPrefab.Length);
        GameObject spawnedCoins = Instantiate(coinsPrefab[jenisCoins], spawnPoint.position, coinsPrefab[jenisCoins].transform.rotation, transform);


        spawnedCoins.transform.localScale = new Vector3(0.3f, 1.0f, 1.0f);

        //memasukkan spawn point kedalam list
        usedSpawnPoints.Add(coinsSpawnIndex);

    }


    private int GetRandomSpawnIndex()
    {
        // Get a random spawn point that has not been used
        int randomIndex;
        do
        {
            randomIndex = Random.Range(1, 10);
        } while (usedSpawnPoints.Contains(randomIndex));

        return randomIndex;
    }
}
