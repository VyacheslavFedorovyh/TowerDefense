using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : ObjectPool
{
	[SerializeField] private List<Wave> _waves;
	[SerializeField] private Transform _spawnPoint;
	[SerializeField] private Player _player;

	private Wave _currentWave;
	private int _currentWaveNumber;
	private float _timeAfterLastSpawn;
	private int _spawned;
	private int _dying;

	public event UnityAction AllEnemySpawned;
	public event UnityAction<int, int> EnemyCountChanget;

	private void Start()
	{
		SetWave(_currentWaveNumber);
		Initialize(_currentWave.Template);
	}

	private void Update()
	{
		if (_currentWave == null)
			return;

		_timeAfterLastSpawn += Time.deltaTime;

		if (_timeAfterLastSpawn >= _currentWave.Delay && TryGetObjecy(out GameObject gameObject))
		{
			SetActiveEnemy(gameObject);
			_spawned++;
			_timeAfterLastSpawn = 0;
			EnemyCountChanget?.Invoke(_spawned, _currentWave.Count);
		}

		if (_currentWave.Count <= _spawned)
			_currentWave = null;
	}

	private void SetActiveEnemy(GameObject gameObject)
	{
		gameObject.SetActive(true);
		gameObject.transform.position = _spawnPoint.position;
		gameObject.transform.rotation = _spawnPoint.rotation;
		gameObject.transform.parent = _spawnPoint;
		Enemy enemy = gameObject.GetComponent<Enemy>();
		enemy.Init(_player);
		enemy.Died += OnEnemyDying;
	}

	private void SetWave(int index)
	{
		_currentWave = _waves[index];
		EnemyCountChanget?.Invoke(0, 1);
	}

	public void NextWave()
	{
		SetWave(++_currentWaveNumber);
		_spawned = 0;
		_dying = 0;
	}

	private void OnEnemyDying(Enemy enemy)
	{
		enemy.Died -= OnEnemyDying;

		_player.AddMoney(enemy.Reward);

		_dying++;

		if (_spawned == _dying)
			AllEnemySpawned?.Invoke();
	}
}

[System.Serializable]
public class Wave
{
	public GameObject Template;
	public float Delay;
	public int Count;
}
