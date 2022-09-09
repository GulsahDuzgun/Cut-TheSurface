using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CutTheSurface.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
        private void Awake()
        {
            this.gameObject.SetActive(true);
            SingletonThisObject(this);
        }
        public void StopGame()
        {
            Time.timeScale = 0f;
        }

        public void LoadScene()
        {
            Debug.Log("Load Scene clicked");
        }

        public void ExitGame()
        {
            Debug.Log("Exit on clicked");
            Application.Quit();
        }
    }
}

