using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalKit : Product
{
	[SerializeField] private int _health;

	public int Health => _health;
}
