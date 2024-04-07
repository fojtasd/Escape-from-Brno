using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvere : MonoBehaviour
{
	public event Action<KeyEnum, bool> KeyMissing;
	public event Action<KeyEnum> ClearKeyMissing;

	[SerializeField] private KeyEnum _requiredKey = KeyEnum.NONE;
	[SerializeField] private DvereTrigger _dvereTrigger;
	[SerializeField] private float _doorMovementAmount = 5f;
	[SerializeField] private float _doorMovementDuration = 1f;
	[SerializeField] private Transform _leftDoor;
	[SerializeField] private Transform _rightDoor;
	[SerializeField] private Renderer _okrajeDveriRenderer;

	private bool _doorClosed = true;

	private void Awake()
	{
		_dvereTrigger.PlayerInTrigger += _OnPlayerInTrigger;
		_dvereTrigger.PlayerOutsideTrigger += _OnPlayerOutsideTrigger;
	}

	private void Start()
	{
		Color color = Color.white;
		switch(_requiredKey)
		{
			case KeyEnum.GREEN:
				color = Color.green;
				break;
			case KeyEnum.RED:
				color = Color.red;
				break;
			case KeyEnum.BLUE:
				color = Color.blue;
				break;
		}

		_okrajeDveriRenderer.material.color = color;
	}

	private void _OnPlayerOutsideTrigger(Player player)
	{
		ClearKeyMissing?.Invoke(_requiredKey);
	
	}

	private void _OnPlayerInTrigger(Player player)
	{
		if((_requiredKey == KeyEnum.NONE || player.HasKey(_requiredKey)) && _doorClosed)
		{
			StartCoroutine(OpenDoors(_doorMovementDuration));
			return;
		}

		KeyMissing?.Invoke(_requiredKey, _doorClosed);
	}

	private IEnumerator OpenDoors(float duration)
	{
		_doorClosed = false;
		float time = 0f;
		float phase = 0f;

		Vector3 leftInitialPosition = _leftDoor.position;
		Vector3 leftFinalPosition = _leftDoor.position + _rightDoor.right * _doorMovementAmount;

		Vector3 rightInitialPosition = _rightDoor.position;
		Vector3 rightFinalPosition = _rightDoor.position - _rightDoor.right * _doorMovementAmount;

		while (time < duration) 
		{
			time += Time.deltaTime;
			phase = time / duration;

			_leftDoor.position = Vector3.Lerp(leftInitialPosition, leftFinalPosition, phase);
			_rightDoor.position = Vector3.Lerp(rightInitialPosition, rightFinalPosition, phase);
			yield return null;
		}
	}
}
