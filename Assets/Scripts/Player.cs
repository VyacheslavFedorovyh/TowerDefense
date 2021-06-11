using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	[SerializeField] private int _health = 100;
	[SerializeField] private List<Weapon> _weapons;
	[SerializeField] private Transform _shootPoint;

	private Weapon _currentWeapon;
	private Animator _animator;

	public int CurrentHealth { get; private set; }
	public int Money { get; private set; }

	private void Start()
	{
		_currentWeapon = _weapons[0];
		CurrentHealth = _health;
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			_currentWeapon.Shoot(_shootPoint);
		}
	}

	private void OnEnemyDied(int reward) 
	{
		Money += reward;
	}

	public void ApplyDamage(int damage)
	{
		CurrentHealth -= damage;
		_animator.Play("Hit");

		if (CurrentHealth <= 0)
			_animator.Play("Died");
	}

	public void AddMoney(int money)
	{
		Money += money;
	}
}
