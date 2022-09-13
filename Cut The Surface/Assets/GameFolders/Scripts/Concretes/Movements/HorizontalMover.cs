using System;
using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Abstracts.Controllers;
using CutTheSurface.Abstracts.Movements;
using CutTheSurface.Controllers;
using UnityEngine;

namespace CutTheSurface.Movements
{
    public class HorizontalMover:IMover
    {
        IEntityController _entityController;
        public HorizontalMover(IEntityController entityController)
        {
            _entityController = entityController;
           
        }

        public void FixedTick (float horizontal)
        {
            if(horizontal==0f){return;}//early return

            _entityController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _entityController.MoveSpeed);
            float moveboundary = Math.Clamp(_entityController.transform.position.x,-_entityController.MoveBoundary,_entityController.MoveBoundary);
            _entityController.transform.position=new Vector3(moveboundary,_entityController.transform.position.y,0f);
        }
    }
    
}

