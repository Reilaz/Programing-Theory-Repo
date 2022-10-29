using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabGood;
    [SerializeField] private GameObject prefabBab;
    [SerializeField] private List<GameObject> ballsGood;
    [SerializeField] private List<GameObject> ballsBad;
    [SerializeField] private List<GameObject> enemyList;

    [SerializeField] private int poolSize = 10;
    // Start is called before the first frame update
    void Start()
    {
        InitPools(enemyList,prefabEnemy);
        InitPools(ballsBad,prefabBab);
        InitPools(ballsGood,prefabGood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitPools(List<GameObject> poolList,GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject objectPool  = Instantiate(prefab);
            objectPool.SetActive(false);
            objectPool.transform.parent = transform;
            poolList.Add(objectPool);
        }
    }
    public GameObject SpawnBalls(int ballType)
    {
        if(ballType > 40)
            return TypeList(ballsGood);
        else
            return TypeList(ballsBad);
    }
    public GameObject SpawnEnemy()
    {
        return TypeList(enemyList);
    }
    GameObject TypeList(List<GameObject> typeList)
    {
        for(int i = 0; i < typeList.Count; i++)
            {
                if (!typeList[i].activeSelf)
                {
                    typeList[i].SetActive(true);
                    return typeList[i];
                }
            }
        return null;
    }
}
