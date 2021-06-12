using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
	[SerializeField] private float _spreadAngle;

	public override void Shot(Transform shotPoint)
	{
		Instantiate(Bullet, shotPoint.position, Quaternion.Euler(0, 0, -_spreadAngle));
		Instantiate(Bullet, shotPoint.position, Quaternion.identity);
		Instantiate(Bullet, shotPoint.position, Quaternion.Euler(0, 0, _spreadAngle));
	}
}
