using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	[Range(100f,10000f)]
	[SerializeField] private float _movementForce = 1500f;
	[Range(1f,25f)]
	[SerializeField] private float _maxPlayerSpeed = 25f;
	[SerializeField] private Player _player;

	private void Update()
	{
		float horizontalAxis = Input.GetAxis("Horizontal");
		if (horizontalAxis != 0)
		{
			_player.Rigidbody.AddForce(horizontalAxis * _player.transform.right * _movementForce, ForceMode.Force);
		}

		float verticalAxis = Input.GetAxis("Vertical");
		if (verticalAxis != 0)
		{
			_player.Rigidbody.AddForce(verticalAxis * _player.transform.forward * _movementForce, ForceMode.Force);
		}

		if (_player.Rigidbody.velocity.magnitude > _maxPlayerSpeed)
		{
			_player.Rigidbody.velocity = _player.Rigidbody.velocity.normalized * _maxPlayerSpeed;
		}
		else if(_player.Rigidbody.velocity.magnitude > 0.25f)
		{

		}
	}

}
