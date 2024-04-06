using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform CameraPosition => _cameraPosition;
	public Transform ShieldPosition => _shieldPosition;
	public Rigidbody Rigidbody => _rigidbody;

	[SerializeField] private Transform _cameraPosition;
	[SerializeField] private Transform _shieldPosition;
	[SerializeField] private Rigidbody _rigidbody;
}
