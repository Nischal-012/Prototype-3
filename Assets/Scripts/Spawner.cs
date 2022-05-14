using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacleSpawn;
    public Vector3 spawnPosition = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    private float spawnTime = 2.0f;
    private float spawnDelay = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomObstacle", spawnTime, spawnDelay);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void SpawnRandomObstacle()
	{
        if (playerControllerScript.gameOver == false)
        {
            int obs = Random.Range(0, obstacleSpawn.Length);
            Instantiate(obstacleSpawn[obs], spawnPosition, gameObject.transform.rotation);
        }
        
    }
}
