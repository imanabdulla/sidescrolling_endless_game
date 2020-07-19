using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [Serializable]
    public class PoolClass
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<PoolClass> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region singleton
    public static ObstaclePool pool;
    private void Awake()
    {
        pool = this;
    }
    #endregion

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            Queue<GameObject> itemsQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject item = Instantiate(pool.prefab);
                item.SetActive(false);
                itemsQueue.Enqueue(item);
            }
            poolDictionary.Add(pool.tag, itemsQueue);
        }

    }
    public GameObject SpawnFromPool(string poolTag, Transform parent)
    {
        var spawnedItem = poolDictionary[poolTag].Dequeue();
        spawnedItem.SetActive(true);
        spawnedItem.transform.parent = parent;
        spawnedItem.transform.localPosition = Vector3.zero;
        spawnedItem.transform.localRotation = Quaternion.identity;
        return spawnedItem;
    }

    public void ReturnToPool(GameObject item, string pooltag)
    {
        poolDictionary[pooltag].Enqueue(item);
        item.SetActive(false);
    }
}
