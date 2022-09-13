using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace CutTheSurface.Controllers
{
    public class FloorController : MonoBehaviour
    {
        [Range(0.5f,3f)]
        [SerializeField] public  float _moveSpeed=0.5f;
        Material [] _material;
        private Vector2 Offset;
       
        void Start()
        {
            _material = GetComponentInChildren<MeshRenderer>().materials;
           
        }

        void Update()
        {
            Offset = _material[0].GetTextureOffset("_BumpMap");
            Offset.y -= _moveSpeed;
            _material[0].SetTextureOffset("_BumpMap", Offset);
          //  r.materials[1].mainTextureScale += Vector2.down * Time.deltaTime * _moveSpeed; 
            
        }
    }
}





















