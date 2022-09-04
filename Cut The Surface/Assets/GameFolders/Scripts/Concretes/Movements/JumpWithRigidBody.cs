using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Controllers;
using UnityEngine;

namespace  CutTheSurface.JumWithRigidBody
{
    public class JumpWithRigidBody
    {
        private Rigidbody _rigidbody;

        public JumpWithRigidBody(PlayerController playerController)
        {
            _rigidbody = playerController.GetComponent<Rigidbody>();
            
        }

        public void TickFixed(float jumpForce)
        {
            if(_rigidbody.velocity.y!=0) return;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up*Time.deltaTime*jumpForce);
        }

    }
}

