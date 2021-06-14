using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Product
{
	[SerializeField] private double _cyclicRate;
	[SerializeField] protected Bullet Bullet;

	public double CyclicRate => _cyclicRate;

	public abstract void Shot(Transform shootPoint);
}
