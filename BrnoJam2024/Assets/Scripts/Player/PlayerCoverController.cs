using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCoverController : MonoBehaviour
{
	[SerializeField] private Shield _shield;

	private void Start()
	{
		SetCoverActive(false);
	}

	public void Update()
	{
	}

	public void SetCoverActive(bool state)
	{
		_shield.gameObject.SetActive(state);
	}
}
