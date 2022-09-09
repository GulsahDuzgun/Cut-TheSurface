using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Managers;
using UnityEngine;

namespace  CutTheSurface.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene();
        }

        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
 
    }
    
}

