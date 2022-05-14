using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacleSpawn;
    public Vector3 spawnPosition = new Vector3(25, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void SpawnRandomObstacle()
	{
        int obs = Random.Range(0, obstacleSpawn.Length);
        Instantiate(obstacleSpawn[obs], spawnPosition, gameObject.transform.rotation);
    }
}
