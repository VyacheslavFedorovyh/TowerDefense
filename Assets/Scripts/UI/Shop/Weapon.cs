using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Product
{
	[SerializeField] private double _cyclicRate;
	[SerializeField] private Bullet _bullet;
	[SerializeField] private AudioSource _shotSound;

	public double CyclicRate => _cyclicRate;
	public Bullet Bullet => _bullet;
	public AudioSource ShotSound => _shotSound;

	public abstract void Shot(GameObject[] bullets, Transform shotPoint);
}
