using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Product
{
	//[SerializeField] private string _label;
	//[SerializeField] private int _price;
	//[SerializeField] private Sprite _icon;
	//[SerializeField] private bool _isBuyed = false;
	[SerializeField] private double _cyclicRate;

	[SerializeField] protected Bullet Bullet;

	//public string Label => _label;
	//public int Price => _price;
	//public Sprite Icon => _icon;
	//public bool IsBuyed => _isBuyed;
	public double CyclicRate => _cyclicRate;

	public abstract void Shot(Transform shootPoint);

	//public void Buy()
	//{
	//	_isBuyed = true;
	//}
}
