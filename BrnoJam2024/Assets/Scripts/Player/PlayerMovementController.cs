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
	[SerializeField] private SoundSettings _soundSettings;

	private float _stepCooldown;

	private const float STEP_DELAY = 0.7f;

	private void FixedUpdate()
	{
		if (_stepCooldown < STEP_DELAY)
		{
			_stepCooldown += Time.fixedDeltaTime;
		}

		float horizontalAxis = Input.GetAxis("Horizontal");
		if (horizontalAxis != 0)
		{
			_player.Rigidbody.AddForce(horizontalAxis * _player.transform.right * _movementForce, ForceMode.Force);
			if (_stepCooldown >= STEP_DELAY)
			{
				PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.footSteps[Random.Range(0, _soundSettings.footSteps.Length)]);
				_stepCooldown = 0f;
			}
		}

		float verticalAxis = Input.GetAxis("Vertical");
		if (verticalAxis != 0)
		{
			_player.Rigidbody.AddForce(verticalAxis * _player.transform.forward * _movementForce, ForceMode.Force);
			if (_stepCooldown >= STEP_DELAY)
			{
				PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.footSteps[Random.Range(0, _soundSettings.footSteps.Length)]);
				_stepCooldown = 0f;
			}
		}

		if (_player.Rigidbody.velocity.magnitude > _maxPlayerSpeed)
		{
			_player.Rigidbody.velocity = _player.Rigidbody.velocity.normalized * _maxPlayerSpeed;
		}
	}

	private void Update()
	{
		
	}

}
