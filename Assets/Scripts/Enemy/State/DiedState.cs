using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DiedState : State
{
	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnEnable()
	{
		_animator.Play("Died");
	}

	private void OnDisable()
	{
		_animator.StopPlayback();
	}
}
