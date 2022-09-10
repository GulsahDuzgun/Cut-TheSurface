using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Controllers;
using CutTheSurface.Enums;
using CutTheSurface.Managers;
using CutTheSurface.Movements;
using UnityEngine;

namespace CutTheSurface.Controllers
{
    public class EnemyController : MyCharacterController,IEntityController
    {
         [SerializeField]  EnemyEnum _enemyEnum;
         [SerializeField] private float _maxLifeTime = 7f;
        
        float _currentLifeTime = 0f; 
        VerticalMover _mover;
        public EnemyEnum EnemyType => _enemyEnum;
     
       
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


