﻿using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
    public abstract class _3D_Base : MonoBehaviour
    {
        [SerializeField]
        protected bool _debugLines = true;
        
        protected GameObject _player;
        protected Vector3 _playerPosition;
		
        [Header("Player")]
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        protected float _playerX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", 0, 50, order = 1)]
        [SerializeField]
        protected float _playerY;
        
        [_CA_Color(0, 1, 255, order = 0)]
        [_CA_Range("Z", -50, 50, order = 1)]
        [SerializeField]
        protected float _playerZ;
        
        // -----
        
        protected GameObject _enemy;
        protected Vector3 _enemyPosition;
        
        protected readonly Vector3 _zero = Vector3.zero;
        
        protected virtual void LateUpdate()
        {
            if (_debugLines)
            {
                DebugLines();
            }
        }
        
        protected virtual void UpdatePlayerPosition()
        {
            _playerPosition = new Vector3(_playerX, _playerY, _playerZ);
            _player.transform.position = _playerPosition;
        }
        
        protected virtual void UpdateEnemyPosition(float enemyX, float enemyY, float enemyZ)
        {
            _enemyPosition = new Vector3(enemyX, enemyY, enemyZ);
            _enemy.transform.position = _enemyPosition;
        }
        
        protected virtual void DebugLines()
        {
            Debug.DrawLine(_zero, _playerPosition, Color.green);
        }
    }
}