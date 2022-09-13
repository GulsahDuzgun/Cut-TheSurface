using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Utilities;
using CutTheSurface.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CutTheSurface.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
       
        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;
      
        public LevelDifficultyData LevelDifficultyData => _levelDifficultyDatas[DifficultyIndex];
        int _difficultyIndex;

        public int DifficultyIndex
        {
            get => _difficultyIndex;
            set
            {//Encapsulation ile 0 ve dizi Lenght aralığı dışında verilen değerlerde menuye oyun yönlendirildi.Kontrol sağlandı.
                if (_difficultyIndex < 0 || _levelDifficultyDatas.Length <= _difficultyIndex)
                {
                    LoadScene("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }
        public event System.Action OnGameStop;
        private void Awake()
        {
            SingletonThisObject(this);
        }

        public void StopGame()
        {
            //Oyunu durduruyoruz
            Time.timeScale = 0f;

            OnGameStop?.Invoke();
            //if(GameStop!= null ){
            // OnGameStopp()
            //}
    }

        public void LoadScene( string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
        

        public void ExitGame()
        {
            Debug.Log("Exit on clicked");
            Application.Quit();
        }
    }
}

