using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenController : MonoBehaviour
{
	[Header("ELEMENTS")]
	[SerializeField] private Image _redKeyImage;
	[SerializeField] private Image _blueKeyImage;
	[SerializeField] private Image _greenKeyImage;
	[SerializeField] private Image _healthbarForeground;
	[SerializeField] private Transform _doorsParent;
	[SerializeField] private TextMeshProUGUI _keyMissingText;
	[Header("SCRIPTS")]
	[SerializeField] private PickupController _PickupController;
	[SerializeField] private PlayerHealthController _PlayerHealthController;

	private void Awake()
	{
		_PickupController.KeyPickup += _OnKeyPickup;
		_PlayerHealthController.HealthChange += _OnHealthChange;

		Dvere[] dvereArray = _doorsParent.GetComponentsInChildren<Dvere>();
		foreach (var dvere in dvereArray)
		{
			dvere.KeyMissing += _OnKeyMissing;
			dvere.ClearKeyMissing += _OnClearKeyMissing;
		}
	}

	private void _OnClearKeyMissing(KeyEnum key)
	{
		_keyMissingText.text = string.Empty;
	}

	private void _OnKeyMissing(KeyEnum key)
	{
		_keyMissingText.text = $"YOU NEED TO COLLECT THE {key} KEY!";
	}

	private void _OnHealthChange(float value)
	{
		_healthbarForeground.fillAmount = value / PlayerHealthController.MAX_HEALTH;
	}

	private void _OnKeyPickup(KeyEnum key)
	{
		switch (key)
		{
			case KeyEnum.BLUE:
				_blueKeyImage.gameObject.SetActive(true);
				break;
			case KeyEnum.RED:
				_redKeyImage.gameObject.SetActive(true);
				break;
			case KeyEnum.GREEN:
				_greenKeyImage.gameObject.SetActive(true);
				break;
		}
	}
}
