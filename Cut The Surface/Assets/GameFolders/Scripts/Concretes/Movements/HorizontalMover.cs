using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Controllers;
using UnityEngine;

namespace CutTheSurface.Movements
{
    public class HorizontalMover
    {
        private PlayerController _playerController;
        float _moveSpeed;
        float _moveboundary;
        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveboundary = _playerController.MoveBoundary;
        }

        public void TickFixed (float horizontal)
        {
            if(horizontal==0f){return;}//early return

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _moveSpeed);
            float moveboundary = Math.Clamp(_playerController.transform.position.x,-_moveboundary,_moveboundary);
            _playerController.transform.position=new Vector3(moveboundary,_playerController.transform.position.y,0f);
        }
    }
    
}

