using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private float _minSpawnRate = 1f;
    private float _maxSpawnRate = 4f;
    private float _spawnRate;
    private float _afterSpawnTime;

    private int _enemyPosition;

    void Start()
    {
        _afterSpawnTime = 0f;
        _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
    }

    
    void Update()
    {
        _afterSpawnTime += Time.deltaTime;

        if (_afterSpawnTime >= _spawnRate)
        {
            _afterSpawnTime = 0f;

            _enemyPosition = Random.Range(0, 3);

            switch(_enemyPosition)
            {
                case 0:
                    Instantiate(_enemyPrefab, Field.EnemyLeftPosition, transform.rotation);
                    break;
                case 1:
                    Instantiate(_enemyPrefab, Field.EnemyMiddlePosition, transform.rotation);
                    break;
                case 2:
                    Instantiate(_enemyPrefab, Field.EnemyRightPosition, transform.rotation);
                    break;
            }

            _spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
        }
    }
}
