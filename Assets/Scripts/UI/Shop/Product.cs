using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product : MonoBehaviour
{
	[SerializeField] private string _label;
	[SerializeField] private int _price;
	[SerializeField] private Sprite _icon;

	public bool IsBuyed = false;

	public string Label => _label;
	public int Price => _price;
	public Sprite Icon => _icon;

	public void Buy()
	{
		IsBuyed = true;
	}
}
