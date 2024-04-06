using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDildoController : MonoBehaviour
{
	public float SwingDuration => _swingDuration;

	[SerializeField] private Dildo _dildo;
	[SerializeField] private float _swingDuration = 0.35f;
	[SerializeField] private float _swingLength = 0.5f;

	private Vector3 _originalPosition;
	private Vector3 _minimumPosition;

	private float _originHeight;

	private void Start()
	{
		_originHeight = _dildo.transform.position.y;
	}

	private void Update()
	{
		_originalPosition = _dildo.transform.position;
		_originalPosition.y = _originHeight;
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
