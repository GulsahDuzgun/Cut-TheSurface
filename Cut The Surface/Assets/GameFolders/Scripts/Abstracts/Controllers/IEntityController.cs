using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  CutTheSurface.Abstracts.Controllers
{
    public interface IEntityController 
    {
        Transform transform { get; }//interfacelerin access modifiersları olmaz
    }
    
}

