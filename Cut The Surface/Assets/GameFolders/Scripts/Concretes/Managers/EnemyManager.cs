using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Utilities;
using CutTheSurface.Controllers;
using CutTheSurface.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace  CutTheSurface.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        //Birden çok çeşit düşmanımız olduğu için bir prefabs dizisi tutulur
        [SerializeField] private EnemyController [] _enemyPrefabs;
        [SerializeField]  float _addDelayTime = 50f;
        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();
        public float AddDelayTime => _addDelayTime;
        public int Count => _enemyPrefabs.Length;
        void Awake()
        {
            SingletonThisObject(this);
        }

        void Start()
        {
            InitializePool();
        }

        void InitializePool()
        {
            Queue<EnemyController> enemyControllers = new Queue<EnemyController>();
            for (int j = 0; j < _enemyPrefabs.Length; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    //Oluşturulan yeni düşma kuyruğa ekleniyor
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[j]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);//Enqueue kuyruğa eleman eklerken dequeue ise dışarı çıkarır
                }
                _enemies.Add((EnemyEnum)j,enemyControllers);
                
            }
          
        }

        public void SetPool(EnemyController enemyController)
        {
            //Görünürlüğü kapatılan enemy tekrar kuyruğa eklniyor
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];
            enemyControllers.Enqueue(enemyController);
        }

       public  EnemyController GetPool(EnemyEnum enemyType)
       {
           Queue<EnemyController> enemyControllers = _enemies[enemyType];
           if (enemyControllers.Count == 0)
           {
               for (int i = 0; i < 2; i++)
               {
                   EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                   enemyControllers.Enqueue(newEnemy); 
               }
               
               
           }

           return  enemyControllers.Dequeue();

       }
        
    }
    
}

