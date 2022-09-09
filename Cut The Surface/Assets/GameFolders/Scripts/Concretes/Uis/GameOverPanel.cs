using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Managers;
using UnityEngine;

namespace CutTheSurface.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void TryAgainButton()
        {
            GameManager.Instance.LoadScene("Game");
        }

        public void QuitButton()
        {
            GameManager.Instance.LoadScene("Menu");
        }

    }
    
}

