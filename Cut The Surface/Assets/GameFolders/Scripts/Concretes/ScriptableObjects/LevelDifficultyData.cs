using System.Collections;
using System.Collections.Generic;
using CutTheSurface.Controllers;
using UnityEngine;

namespace  CutTheSurface.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty",menuName = "Create Difficulty/Create New",order = 1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField]  FloorController _floorPrefab;
        [SerializeField]  GameObject _spawnerPrefabs;
        [SerializeField]  Material _skyboxMaterial;
        [SerializeField]  float _moveSpeed = 10f;
        [SerializeField] private float _addDelayTime=50f;
        public FloorController FloorPrefab => _floorPrefab;
        public GameObject SpawnerPrefab => _spawnerPrefabs;
        public Material SkyboxMaterial => _skyboxMaterial;

        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;

    }
    
}

