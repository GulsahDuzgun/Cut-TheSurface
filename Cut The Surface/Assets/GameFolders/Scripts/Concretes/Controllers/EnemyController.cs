using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Managers;
using CutTheSurface.Movements;
using UnityEngine;

namespace CutTheSurface.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]  float _moveSpeed=10f;
        [SerializeField] private float _maxLifeTime = 7f;
        public float MoveSpeed => _moveSpeed;
        float _currentLifeTime = 0f; 
        VerticalMover _mover;
        
        void Awake()
        {
            _mover = new VerticalMover(this);
        }

        void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void KillYourself()
        {
            EnemyManager.Instance.SetPool(this); 
        }
    }
    
}


