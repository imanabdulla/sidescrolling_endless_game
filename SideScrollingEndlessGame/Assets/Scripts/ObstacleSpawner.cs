using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private string[] poolTags;
    Coroutine coroutine;
    bool isSpawning;

    void Start()
    {
        GameManager.gameManager.OnGameplayStart += StartSpawning;
        GameManager.gameManager.OnGameplayEnd += StopSpawning;
    }

    void StartSpawning()
    {
        coroutine = StartCoroutine("Spawn");
    }

    void StopSpawning()
    {
        if (coroutine != null)
        {
            isSpawning = false;
            StopCoroutine("Spawn");
            coroutine = null;
        }
    }


    IEnumerator Spawn()
    {
        isSpawning = true;
        while (true)
        {
            //get a random pool from the obstacle pools
            var index = UnityEngine.Random.Range(0, poolTags.Length);
            var poolTag = poolTags[index];

            //set the delay with a random value
            var delay = UnityEngine.Random.Range(2, 5);

            //spawn items from this pool
            ObstaclePool.pool.SpawnFromPool(poolTag, this.transform);

            yield return new WaitForSeconds(delay);
        }
    }
}
