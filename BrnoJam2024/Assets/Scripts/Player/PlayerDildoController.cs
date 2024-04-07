using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDildoController : MonoBehaviour
{
	public float SwingDuration => _swingDuration;

	[SerializeField] private Dildo _dildo;
	[SerializeField] private Player _player;
	[SerializeField] private float _swingDuration = 0.35f;
	[SerializeField] private float _swingLength = 0.5f;

	private Vector3 _originalPosition;
	private Vector3 _minimumPosition;

	private void Start()
	{
		_originalPosition = _dildo.transform.position;
		_originalPosition.y = _player.transform.position.y + 1.6f;
		_dildo.transform.position = _originalPosition;
	}

	private void Update()
	{
		_originalPosition = _dildo.transform.position;
		_originalPosition.y = _player.transform.position.y + 1.6f;
		_minimumPosition = new Vector3(_originalPosition.x, _originalPosition.y - _swingLength, _originalPosition.z);
	}

	public void Downswing(float phase)
	{
		Vector3 position = Vector3.Lerp(_originalPosition, _minimumPosition, phase);
		_dildo.transform.position = position;
	}

	public void BackToNormal(float phase)
	{
		Vector3 position = Vector3.Lerp(_minimumPosition, _originalPosition, phase);
		_dildo.transform.position = position;
	}

}
