using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pistol : Weapon
{
	public override void Shot(GameObject[] bullets, Transform shotPoint)
	{
		bullets.FirstOrDefault().SetActive(true);
		bullets.FirstOrDefault().transform.position = shotPoint.position;
		ShotSound.Play(0);
	}
}
