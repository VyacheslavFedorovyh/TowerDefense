using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
	[SerializeField] private Button _restartButton;
	[SerializeField] private TMP_Text _label;

	private void Start()
	{
		_label.gameObject.SetActive(false);
		_restartButton.gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		_player.Died += OnDied;
		_restartButton.onClick.AddListener(OnRestartButtonClick);
	}

	private void OnDisable()
	{
		_player.Died -= OnDied;
		_restartButton.onClick.RemoveListener(OnRestartButtonClick);
	}

	private void OnDied()
	{
		_label.gameObject.SetActive(true);
		_restartButton.gameObject.SetActive(true);
	}

	private void OnRestartButtonClick()
	{
		_label.gameObject.SetActive(false);
		_restartButton.gameObject.SetActive(false);

		SceneManager.LoadScene(0);
	}

}
