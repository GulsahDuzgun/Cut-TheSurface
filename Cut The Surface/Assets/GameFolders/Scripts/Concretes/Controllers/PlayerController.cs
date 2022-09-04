using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.JumWithRigidBody;
using CutTheSurface.Movements;
using UnityEngine;

namespace CutTheSurface.Controllers
{
    
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _horizontalDirection = 0f;
        [SerializeField] private float _addForce=300f;
        [SerializeField] private bool isJump;
        
        private HorizontalMover _horizontalMover;
        private JumpWithRigidBody _jumpWithRigidBody;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidBody = new JumpWithRigidBody(this);
        }

        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_moveSpeed,_horizontalDirection);

            if (isJump)
            {
                _jumpWithRigidBody.TickFixed(_addForce);
                isJump = false;
            }
            
        }
    }
    
}

