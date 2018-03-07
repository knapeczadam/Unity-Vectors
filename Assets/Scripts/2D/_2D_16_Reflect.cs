﻿using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_16_Reflect : MonoBehaviour 
	{
		private GameObject _player;
		private Vector2 _playerPosition;
		
		[Header("Player")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _playerY;
		
		// -----
		
		[Space]
		
		[_CA_Color(_Color.Cyan, order = 0)]
		[_CA_Range(0, 359, order = 1)]
		[SerializeField]
		private int _degrees;
		
		[Header("Plane")]	
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("*", 1, 50, order = 1)]
		[SerializeField]
		private float _k = 1;

		private Vector2 _inNormal;
		private Vector2 _inDirection;
		
		private GameObject _enemy;
		
		private readonly Vector2 _zero = Vector2.zero;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/RT7AWaSF
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePlayerPosition();
			
			_inNormal = _player.transform.position;
			/*
			 * Q: What is radian?
			 *
			 * Q: What is Mathf.Deg2Rad?
			 *
			 * Q: What's the opposite of Mathf.Deg2Rad?
			 */
			_inDirection = new Vector2(Mathf.Cos((_degrees * Mathf.PI) / 180), Mathf.Sin((_degrees * Mathf.PI) / 180));
			
			_enemy.transform.position = Vector2.Reflect(_inNormal, _inDirection);
		}
		
		private void LateUpdate()
		{
			DebugLines();
		}

		private void UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
		}

		private void DebugLines()
		{
			Debug.DrawLine(_zero, _inDirection, Color.cyan);
			Vector2 plane = new Vector2(_inDirection.y, -_inDirection.x);
			Debug.DrawLine(-plane * _k, plane * _k, Color.white);
		}
	}
}
