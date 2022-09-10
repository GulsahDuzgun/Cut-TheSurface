using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  CutTheSurface.Abstracts.Controllers
{
    public abstract class MyCharacterController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 10f;
        [SerializeField] private float _moveBoundary=4.5f;

        public float MoveSpeed => _moveSpeed;
        public float MoveBoundary => _moveBoundary;
    }
}

