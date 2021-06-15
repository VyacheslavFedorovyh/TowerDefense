using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] private GameObject _container;
	[SerializeField] private int _capacity;

	protected List<GameObject> _pool = new List<GameObject>();

	protected void Initialize(GameObject prefab)
	{
		for (int i = 0; i < _capacity; i++)
		{
			GameObject spawned = Instantiate(prefab, _container.transform);
			spawned.SetActive(false);

			_pool.Add(spawned);
		}
	}

	protected bool TryGetObjecy(out GameObject[] result)
	{
		result = _pool
			.Where(p => p.activeSelf == false)
			.Take(3)
			.ToArray();

		return result != null;
	}

	protected bool TryGetObjecy(out GameObject result)
	{
		result = _pool.FirstOrDefault(p => p.activeSelf == false);

		return result != null;
	}

	protected void RemoveObjecy()
	{
		foreach (GameObject pool in _pool)
		{
			Destroy(pool);
		}
		_pool.Clear();
	}
}
