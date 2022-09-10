using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Utilities;
using CutTheSurface.Controllers;
using UnityEngine;

namespace  CutTheSurface.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        [SerializeField] private EnemyController _enemyPrefab;
        private Queue<EnemyController> _enemies = new Queue<EnemyController>();

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
            for (int i = 0; i < 10; i++)
            {
                //Oluşturulan yeni düşma kuyruğa ekleniyor
                EnemyController newEnemy = Instantiate(_enemyPrefab);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                _enemies.Enqueue(newEnemy);//Enqueue kuyruğa eleman eklerken dequeue ise dışarı çıkarır
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            //Görünürlüğü kapatılan enemy tekrar kuyruğa eklniyor
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            _enemies.Enqueue(enemyController);
        }

       public  EnemyController GetPool()
        {
            //Düşman havuzdan çıkarılıyor
            if (_enemies.Count == 0)
            {
                InitializePool();
            }

            return _enemies.Dequeue();
        }
        
    }
    
}

