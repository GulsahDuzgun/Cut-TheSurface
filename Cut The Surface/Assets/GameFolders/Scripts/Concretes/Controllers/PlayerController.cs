using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Inputs;
using CutTheSurface.JumWithRigidBody;
using CutTheSurface.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CutTheSurface.Controllers
{
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _addForce=300f;
        [SerializeField] private float _moveBoundary=4.5f;
       
        private IInputReader _input;
        float _horizontal;
        bool _isJump;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidBody _jumpWithRigidBody;
        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;
        
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidBody = new JumpWithRigidBody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        void Update()
        {
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
            _horizontalMover.TickFixed(_horizontal );

            if (_isJump)
            {
                _jumpWithRigidBody.TickFixed(_addForce);
                _isJump = false;
            }
            
        }
    }
    
}

