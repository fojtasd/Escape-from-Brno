using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
	public event Action<KeyEnum> KeyPickup;

	[SerializeField] private Player _player;

	private void Awake()
	{
		_player.Collector.CollectedItem += _OnCollectedItem;
		_player.Collector.AfterCollectedItem += _OnAfterCollectedItem;
	}

	private void _OnAfterCollectedItem(Collectible collectible)
	{
		Destroy(collectible.gameObject);
	}

	private void _OnCollectedItem(Collectible collectible)
	{
		switch (collectible)
		{
			case Key key:
				KeyPickup?.Invoke(key.KeyEnum);
				_player.AddKey(key.KeyEnum);
				break;
		}
	}


}
