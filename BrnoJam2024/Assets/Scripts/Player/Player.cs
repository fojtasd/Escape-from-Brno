using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform CameraPosition => _cameraPosition;
	public Transform ShieldPosition => _shieldPosition;
	public Rigidbody Rigidbody => _rigidbody;
	public Collector Collector => _collector;

	public PlayerDamageDetector PlayerDamageDetector => _playerDamageDetector;
	public PlayerTurretContactDetector PlayerTurretContactDetector => _playerTurretContactDetector;

	private List<KeyEnum> _keys = new List<KeyEnum>();

	public void AddKey(KeyEnum key)
	{
		if (key == KeyEnum.NONE)
			return;

		if(!_keys.Contains(key))
			_keys.Add(key);
	}

	public bool HasKey(KeyEnum key)
	{
		return _keys.Contains(key);
	}

	[SerializeField] private Transform _cameraPosition;
	[SerializeField] private Transform _shieldPosition;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Collector _collector;
	[SerializeField] private PlayerDamageDetector _playerDamageDetector;
	[SerializeField] private PlayerTurretContactDetector _playerTurretContactDetector;
}
