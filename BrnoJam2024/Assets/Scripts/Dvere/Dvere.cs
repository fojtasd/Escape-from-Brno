using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvere : MonoBehaviour
{
	public event Action<KeyEnum> KeyMissing;
	public event Action<KeyEnum> ClearKeyMissing;

	[SerializeField] private KeyEnum _requiredKey = KeyEnum.NONE;
	[SerializeField] private DvereTrigger _dvereTrigger;
	[SerializeField] private float _doorMovementAmount = 5f;
	[SerializeField] private float _doorMovementDuration = 1f;
	[SerializeField] private Transform _leftDoor;
	[SerializeField] private Transform _rightDoor;

	private bool _doorClosed = true;

	private void Awake()
	{
		_dvereTrigger.PlayerInTrigger += _OnPlayerInTrigger;
	}

	private void _OnPlayerInTrigger(Player player)
	{
		if((_requiredKey == KeyEnum.NONE || player.HasKey(_requiredKey)) && _doorClosed)
		{
			StartCoroutine(OpenDoors(_doorMovementDuration));
			return;
		}

		KeyMissing?.Invoke(_requiredKey);
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
