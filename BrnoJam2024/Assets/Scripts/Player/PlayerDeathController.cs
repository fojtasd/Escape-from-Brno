using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
	[SerializeField] private PlayerHealthController _playerHealthController;

	private void Awake()
	{
		_playerHealthController.HealthChange += _OnHealthChange;
	}

	private void _OnHealthChange(float health)
	{
		if(health == 0)
		{
			SceneManager.LoadScene("DefeatScreen");
		}
	}
}