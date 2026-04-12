using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    public GameObject obstaclePrefab;



    private float statrtDelay = 2;

    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", statrtDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int RandomY = Random.Range(4, 11);

        Vector3 spawnPos = new Vector3 (20, RandomY , 0);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
