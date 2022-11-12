using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    //Begin Encapsulatio
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject prefabGood;
    [SerializeField] private GameObject prefabBab;
    [SerializeField] private GameObject prefabSlower;
    [SerializeField] private List<GameObject> ballsGood;
    [SerializeField] private List<GameObject> ballsBad;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<GameObject> ballsSlower;
    [SerializeField] private int poolSize = 10;
    //End Encapsulation
    
    void Start()
    {
        InitPools(enemyList,prefabEnemy);
        InitPools(ballsBad,prefabBab);
        InitPools(ballsGood,prefabGood);
        InitPools(ballsSlower,prefabSlower);
    }
    //Begin Abstraction Methods
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
        if(ballType < 40)
            return TypeList(ballsBad);
        else if(ballType > 40 && ballType < 70)
            return TypeList(ballsGood);
        else
            return TypeList(ballsSlower);
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
    //End Abstraction Methods
}
