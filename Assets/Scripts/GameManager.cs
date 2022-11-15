using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Begin Encapsulation
    private PoolController poolController;
    private PlayerController playerController;

    [Header("System Settings")]
    private float spawnRangeX = 10.0f;
    private float spawnPosY = 15.0f;
    private float spawnPosX = 16.0f;
    private float startDelay = 1.0f;
    private float spawnInterval = 1.0f;
    private bool isInvoke;
    private bool isPause;
    //private TextMeshProUGUI stateGameText;
    //private bool isPlay;
    //End Encapsulation
    public Text counterText;
    public GameObject menu;


    void Start()
    {
        poolController = GameObject.Find("PoolObjects").GetComponent<PoolController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        
        DisplayCounterPlayer();
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
    IEnumerator DelayEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            EnemyInvoker();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void DisplayCounterPlayer()
    {
        counterText.text = "Count: " + playerController.CounterValue;
    }
    public void ReturnMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    void PauseGame()
    {
        if(!isPause)
        {
            isPause = true;
            menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            isPause = false;
            menu.SetActive(false);
            Time.timeScale = 1.0f;
        }
        
    }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}