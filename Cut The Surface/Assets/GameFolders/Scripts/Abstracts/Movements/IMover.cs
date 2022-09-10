using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CutTheSurface.Abstracts.Movements
{
    public interface IMover
    {
        void FixedTick(float direction);
    }
    
}

