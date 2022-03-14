using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _minSpawnRate = 1f;
    private float _maxSpawnRate = 2f;
    private float _spawnRate;
    private float _afterSpawnTime;

    private int _enemyPosition;
    private Enemy _enemyPrefab;

    void Start()
    {
        _afterSpawnTime = 0f;
        _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    
    void Update()
    {
        _afterSpawnTime += Time.deltaTime;

        if (false == GameManager.instance.IsSkillActive && false == GameManager.instance.IsGameOver && _afterSpawnTime >= _spawnRate)
        {
            _afterSpawnTime = 0f;

            _enemyPosition = Random.Range(0, 3);
            getEnemy();
            _enemyPrefab.transform.rotation = transform.rotation;

            switch (_enemyPosition)
            {
                case 0:
                    _enemyPrefab.transform.position = Field.EnemyLeftPosition;
                    break;
                case 1:
                    _enemyPrefab.transform.position = Field.EnemyMiddlePosition;
                    break;
                case 2:
                    _enemyPrefab.transform.position = Field.EnemyRightPosition;
                    break;
            }

            _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
        }
    }

    private void getEnemy()
    {
        int randomNum = Random.Range(0, 2);

        switch (randomNum)
        {
            case (int)EnemyType.SkeletonSlave:
                _enemyPrefab = ObjectPool.GetSkeletonSlave();
                break;
            case (int)EnemyType.Boom:
                _enemyPrefab = ObjectPool.GetBoom();
                break;
        }
    }
}
