using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _speed;

	void Update()
	{
		transform.Translate(-transform.right * _speed * Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Enemy enemy))
		{
			enemy.TakeDamage(_damage);
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		gameObject.SetActive(false);
	}
}
