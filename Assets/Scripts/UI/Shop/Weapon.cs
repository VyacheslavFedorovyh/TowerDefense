using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Product
{
	[SerializeField] private double _cyclicRate;
	[SerializeField] private Bullet _bullet;

	public Bullet Bullet => _bullet;
	public double CyclicRate => _cyclicRate;

	public abstract void Shot(GameObject[] bullets, Transform shotPoint);
}
