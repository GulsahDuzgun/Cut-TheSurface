using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Movements;
using CutTheSurface.Controllers;
using UnityEngine;

namespace  CutTheSurface.JumWithRigidBody
{
    public class JumpWithRigidBody:IJump
    {
        private Rigidbody _rigidbody;
        
        //velocity sabit hızı temsil eder ve zıplama anında  y eksenindeki hız sabit olmadığı için burası false döner 
        public bool CanJump => _rigidbody.velocity.y != 0f;

        public JumpWithRigidBody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
            
        }

        public void FixedTick(float jumpForce)
        {
            if (CanJump) return;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up*Time.deltaTime*jumpForce);
            
        }
        
    }
}

