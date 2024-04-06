using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenController : MonoBehaviour
{
	[Header("ELEMENTS")]
	[SerializeField] private Image _redKeyImage;
	[SerializeField] private Image _yellowKeyImage;
	[SerializeField] private Image _greenKeyImage;

	[Header("SCRIPTS")]
	[SerializeField] private PickupController _PickupController;

	private void Awake()
	{
		_PickupController.KeyPickup += _OnKeyPickup;
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
