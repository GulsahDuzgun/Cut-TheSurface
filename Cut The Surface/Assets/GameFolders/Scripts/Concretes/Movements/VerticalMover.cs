using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Controllers;
using CutTheSurface.Abstracts.Movements;
using CutTheSurface.Controllers;
using UnityEngine;

namespace CutTheSurface.Movements
{
    public class VerticalMover:IMover
    {
        IEntityController _entityController;
        float _moveSpeed;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            _moveSpeed = _entityController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1 )
        {
            _entityController.transform.Translate(Vector3.back * vertical * _moveSpeed * Time.deltaTime);
        }


    }
}

