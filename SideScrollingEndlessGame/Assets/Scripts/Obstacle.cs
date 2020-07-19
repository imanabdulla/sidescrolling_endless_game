using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private string poolTag;
    [SerializeField] private float speed;

    bool stop;

    private void Start()
    {
        GameManager.gameManager.OnGameplayEnd += Stop;
    }

    void Update()
    {
        if(!stop)
            Move();
    }

    void Move()
    {
        transform.Translate(-transform.right * Time.deltaTime * speed);
    }

    void Stop()
    {
        stop = true;
    }

    void OnBecameInvisible()
    {
        ObstaclePool.pool.ReturnToPool(gameObject, poolTag);
    }
}
