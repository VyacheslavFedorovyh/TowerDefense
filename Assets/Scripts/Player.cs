using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	[SerializeField] private int _health = 100;
	[SerializeField] private List<Weapon> _weapons;
	[SerializeField] private Transform _shotPoint;

	private Weapon _currentWeapon;
	private int _currentWeaponNumber = 0;
	private Animator _animator;
	private float _timeAfterLastShot;

	public int CurrentHealth { get; private set; }
	public int Money { get; private set; }

	public event UnityAction<int,int> HealthChanged;
	public event UnityAction<int> MoneyChanged;
	public event UnityAction Died;

	private void Start()
	{
		ChangeWeapon(_weapons[_currentWeaponNumber]);
		_currentWeapon = _weapons[0];
		CurrentHealth = _health;
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		_timeAfterLastShot += Time.deltaTime;

		if (Input.GetMouseButtonDown(0) && CurrentHealth > 0 
			&& _timeAfterLastShot >= _currentWeapon.CyclicRate && Time.timeScale >= 0)
		{
			_currentWeapon.Shot(_shotPoint);
			_animator.Play("Shot");
			_timeAfterLastShot = 0;
		}
	}

	public void ApplyDamage(int damage)
	{
		CurrentHealth -= damage;
		HealthChanged?.Invoke(CurrentHealth, _health);
		_animator.Play("Hit");

		if (CurrentHealth <= 0)
		{
			_animator.Play("Died");
			Died?.Invoke();
		}
	}

	public void AddMoney(int money)
	{
		Money += money;
		MoneyChanged?.Invoke(Money);
	}

	public void BuyProduct(Product product)
	{
		Money -= product.Price;
		MoneyChanged?.Invoke(Money);

		if (product is MedicalKit)	
			CurrentHealth += ((MedicalKit)product).Health;		
		else
			_weapons.Add((Weapon)product);
	}

	public void NextWeapon()
	{
		if (_currentWeaponNumber == _weapons.Count - 1)
			_currentWeaponNumber = 0;
		else
			_currentWeaponNumber++;

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	public void PreviousWeapon()
	{
		if (_currentWeaponNumber == 0)
			_currentWeaponNumber = _weapons.Count - 1;
		else
			_currentWeaponNumber--;

		ChangeWeapon(_weapons[_currentWeaponNumber]);
	}

	private void ChangeWeapon(Weapon weapon)
	{
		_currentWeapon = weapon;
	}
}
