using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Enums;
using CutTheSurface.Managers;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace CutTheSurface.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
       
        [Range(0.1f,5f)][SerializeField] float _min=0.1f;
        [Range(6f, 15f)] [SerializeField] private float _max = 15f;

        float _maxSpawnTime;
        float _currentSpawnTime=0f;
        private int _index = 0;
        private float _maxAddEnemyTime;
        public bool CanIncrease => _index < EnemyManager.Instance.Count;
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
            if(!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        void Spawn()
        {  
            EnemyController newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,4));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }

        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

        void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
    
}


