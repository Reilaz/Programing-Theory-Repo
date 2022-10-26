using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> balls;
    public GameObject blockLeft;
    public GameObject blockRight;

    private float spawnRate = 1.0f;
    private float spawnRangeX = 10.0f;
    private float spawnPosY = 15.0f;
    private float spawnPosX = 16.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnBalls",startDelay,spawnInterval);
        InvokeRepeating("SpawnBlocks",spawnRate,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnBalls()
    {
        int index = Random.Range(0,balls.Count);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),spawnPosY,0);
        Instantiate(balls[index],spawnPos,balls[index].transform.rotation);
    }
    void SpawnBlocks()
    {
        Vector3 spawnPosEnemyLeft = new Vector3(-spawnPosX,Random.Range(7,10),0);
        Vector3 spawnPosEnemySideRight = new Vector3(spawnPosX,Random.Range(2,6),0);
        Instantiate(blockLeft,spawnPosEnemyLeft,blockLeft.transform.rotation);
        Instantiate(blockRight,spawnPosEnemySideRight,blockRight.transform.rotation);
    }
}
