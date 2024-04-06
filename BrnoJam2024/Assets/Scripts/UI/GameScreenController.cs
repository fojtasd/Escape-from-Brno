using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenController : MonoBehaviour
{
	[Header("ELEMENTS")]
	[SerializeField] private Image _redKeyImage;
	[SerializeField] private Image _yellowKeyImage;
	[SerializeField] private Image _greenKeyImage;
	[SerializeField] private Image _healthbarForeground;
	[Header("SCRIPTS")]
	[SerializeField] private PickupController _PickupController;
	[SerializeField] private PlayerHealthController _PlayerHealthController;

	private void Awake()
	{
		_PickupController.KeyPickup += _OnKeyPickup;
		_PlayerHealthController.HealthChange += _OnHealthChange;
	}

	private void _OnHealthChange(float value)
	{
		_healthbarForeground.fillAmount = value / PlayerHealthController.MAX_HEALTH;
	}

	private void _OnKeyPickup(KeyEnum key)
	{
		switch (key)
		{
			case KeyEnum.YELLOW:
				_yellowKeyImage.gameObject.SetActive(true);
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
