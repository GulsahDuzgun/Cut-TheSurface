using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Controllers;
using CutTheSurface.Abstracts.Inputs;
using CutTheSurface.Abstracts.Movements;
using CutTheSurface.JumWithRigidBody;
using CutTheSurface.Managers;
using CutTheSurface.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CutTheSurface.Controllers
{
    
    public class PlayerController : MyCharacterController,IEntityController
    {
        [SerializeField]  float _addForce = 300f;
        private IInputReader _input;
        float _horizontal;
        bool _isJump;
        bool _isdead = false;
        
         IMover _mover;
         IJump _jumpWithRigidBody;
  
        
        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jumpWithRigidBody = new JumpWithRigidBody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        void Update()
        {
            if(_isdead==true) return;
            _horizontal=_input.Horizontal;
            _isJump = _input.IsJump;

            if (_input.IsJump)
            {
                _isJump = true;
            }

        }

        private void FixedUpdate()
        {
            Debug.Log(_isJump);
            _mover.FixedTick(_horizontal );

            if (_isJump)
            {
                _jumpWithRigidBody.FixedTick(_addForce);
                _isJump = false;
            }
            
        }

        void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();
            if (entityController != null)
            {
                _isdead = true;
                GameManager.Instance.StopGame();
            }
        }
    }
    
}

