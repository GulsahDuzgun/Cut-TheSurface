using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Managers;
using UnityEngine;

namespace  CutTheSurface.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton (int index)
        {
            GameManager.Instance.DifficultyIndex = index;
            GameManager.Instance.LoadScene("Game");
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
 
    }
    
}

