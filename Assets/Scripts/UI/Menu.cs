using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject _startPanel;
	[SerializeField] private AudioSource _backgroundSound;

	private void Start()
	{
		OpenPanel(_startPanel);
	}

	public void OpenPanel(GameObject panel)
	{
		panel.SetActive(true);
		Time.timeScale = 0;
	}

	public void ClosePanel(GameObject panel)
	{
		panel.SetActive(false);
		Time.timeScale = 1; 
	}

	public void CloseStartPanel(GameObject panel)
	{
		PlayBackgroundSound();
		ClosePanel(panel);
	}

	public void PlayBackgroundSound()
	{
		_backgroundSound.Play(0);
	}

	public void PauseBackgroundSound()
	{
		_backgroundSound.Pause();
	}

	public void Exit()
	{
		Application.Quit();
	}
}
