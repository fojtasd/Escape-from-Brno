using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Transform CameraPosition => _cameraPosition;
	public Rigidbody Rigidbody => _rigidbody;

	[SerializeField] private Transform _cameraPosition;
	[SerializeField] private Rigidbody _rigidbody;
}
