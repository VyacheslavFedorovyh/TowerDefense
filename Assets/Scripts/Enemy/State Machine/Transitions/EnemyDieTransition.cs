using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDieTransition : Transition
{
	private Enemy _enemy;

	private void Awake()
	{
		_enemy = GetComponent<Enemy>();
	}

	private void OnEnable()
	{
		_enemy.Died += Died;
	}

	private void Died(Enemy enemy)
	{
		_enemy.Died -= Died;

		NeedTransit = true;
	}	
}
