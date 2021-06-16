using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButton;
	[SerializeField] private Menu _menu;

	private void OnEnable()
	{
		_spawner.AllEnemySpawned += OnAllEnemySpawned;
		_nextWaveButton.onClick.AddListener(OnNextWaveButtonClick);
	}

	private void OnDisable()
	{
		_spawner.AllEnemySpawned -= OnAllEnemySpawned;
		_nextWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
	}

	public void OnAllEnemySpawned()
	{
		_menu.PauseBackgroundSound();
		_nextWaveButton.gameObject.SetActive(true);
	}

	public void OnNextWaveButtonClick()
	{
		_menu.PlayBackgroundSound();
		_spawner.NextWave();
		_nextWaveButton.gameObject.SetActive(false);
	}
}
