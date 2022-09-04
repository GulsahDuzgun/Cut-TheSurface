using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Controllers;
using UnityEngine;

namespace CutTheSurface.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void TickFixed (float horizontal, float moverSpeed)
        {
            if(horizontal==0f){return;}//early return

            _playerController.transform.Translate(Vector3.right * horizontal * moverSpeed * Time.deltaTime);
            
        }
    }
    
}

