using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CutTheSurface.Abstracts.Inputs
{
    public interface IInputReader 
    {
        //interfacelerin access modifierslar─▒ olmaz
        float Horizontal { get; }
        bool IsJump { get; }
    }
    
}

