using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
	[SerializeField] private int _health;
	[SerializeField] private int _reward;

	private Player _target;

	public int Reward => _reward;
	public Player Target => _target;

	public event UnityAction<Enemy> Died;

	public void Init(Player target)
	{
		_target = target;
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health < 0)
		{
			Died?.Invoke(this);
			GetComponent<BoxCollider2D>().isTrigger = false;
			Destroy(gameObject, 8f);
		}
	}
}
