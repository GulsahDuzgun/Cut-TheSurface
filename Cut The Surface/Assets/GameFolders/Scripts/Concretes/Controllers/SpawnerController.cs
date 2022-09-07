using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace CutTheSurface.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemyController _enemyprefab;
        [Range(0.1f,5f)][SerializeField] float _min=0.1f;
        [Range(6f, 15f)] [SerializeField] private float _max = 15f;

        float _maxSpawnTime;
        float _currentSpawnTime=0f;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }

        void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if (_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }
        }

        void Spawn()
        {
            EnemyController newEnemy=Instantiate(_enemyprefab, transform.position, transform.rotation);
            newEnemy.transform.parent = this.transform;

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }
    }
    
}


