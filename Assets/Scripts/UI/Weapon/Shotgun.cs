using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shotgun : Weapon
{
	[SerializeField] private float _spreadAngle;	

	public override void Shot(GameObject[] bullets, Transform shotPoint)
	{
		int selector = -1;

		foreach (var bullet in bullets)
		{
			bullet.SetActive(true);
			bullet.transform.position = shotPoint.position;
			bullet.transform.rotation = Quaternion.Euler(0, 0, _spreadAngle * selector);

			selector++;
		}
	}
}
