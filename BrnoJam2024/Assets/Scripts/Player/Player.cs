using System.Collections;
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

	[SerializeField] private Transform _cameraPosition;
	[SerializeField] private Transform _shieldPosition;
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Collector _collector;
	[SerializeField] private PlayerDamageDetector _playerDamageDetector;
	[SerializeField] private PlayerTurretContactDetector _playerTurretContactDetector;
}
