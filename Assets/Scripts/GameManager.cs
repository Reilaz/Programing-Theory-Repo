using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PoolController poolController;

    [Header("System Settings")]
    //private float spawnRate = 10.0f;
    private float spawnRangeX = 10.0f;
    private float spawnPosY = 15.0f;
    private float spawnPosX = 16.0f;
    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;
    private bool isInvoke;

    // Start is called before the first frame update
    void Start()
    {
        poolController = GameObject.Find("PoolObjects").GetComponent<PoolController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        StartCoroutine(DelayBall());
        StartCoroutine(DelayEnemy());
    }
    void BallInvoker()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX),spawnPosY,0);
        int ballType = Random.Range(0,100);
        GameObject ball = poolController.SpawnBalls(ballType);
        ball.transform.position = spawnPos;
    }
    void EnemyInvoker()
    {
        Vector3 spawnPos = new Vector3(-spawnPosX,Random.Range(3,9),0);
        GameObject enemy = poolController.SpawnEnemy();
        enemy.transform.position = spawnPos;
    }
    IEnumerator DelayBall()
    {
        yield return new WaitForSeconds(startDelay);
        while(true)
        {
            BallInvoker();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnBlocks()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            EnemyInvoker();
            yield return new WaitForSeconds(0.5f);
        }
    }
}