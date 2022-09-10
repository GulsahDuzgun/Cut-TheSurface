using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Managers;
using UnityEngine;

namespace CutTheSurface.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameOverPanel _gameOverPanel;

        private void Awake()
        
        {
            _gameOverPanel.gameObject.SetActive(false);
        }

        void OnEnable()
        {
            GameManager.Instance.OnGameStop += HandleOnGameStop;
        }

        void OnDisable()
        {
            GameManager.Instance.OnGameStop -= HandleOnGameStop;
        }

        void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }
    }

}


