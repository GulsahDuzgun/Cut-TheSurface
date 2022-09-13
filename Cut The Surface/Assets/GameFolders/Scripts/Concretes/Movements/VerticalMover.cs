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

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
        }

        public void FixedTick(float vertical = 1 )
        {
            _entityController.transform.Translate(Vector3.back * vertical *_entityController.MoveSpeed * Time.deltaTime);
        }


    }
}

