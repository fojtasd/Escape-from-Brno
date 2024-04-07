using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDildoDamageController : MonoBehaviour
{

	[SerializeField] private Camera _camera;
	[SerializeField] private Player _player;
	[SerializeField] private float _damage = 25f;

	private Turret _turretInRange;
	private Coroutine _turretInRangeCoroutine;


	private void Awake()
	{
		_player.PlayerTurretContactDetector.CollisionWithTurret += _OnCollisionWithTurret;
		_player.PlayerTurretContactDetector.EndCollisionWithTurret += _OnEndCollisionWithTurret;
	}

	private void _OnEndCollisionWithTurret(Turret turret)
	{
		_turretInRangeCoroutine = StartCoroutine(_TurretRangeCooldown(0.35f));
	}

	private void _OnCollisionWithTurret(Turret turret)
	{
		if (_turretInRangeCoroutine != null)
			StopCoroutine(_turretInRangeCoroutine);

		_turretInRange = turret;
	}

	public void Damage()
	{
		if(_turretInRange != null)
		{
			_turretInRange.Damage(_damage);
		}
	}

	private void Update()
	{

	}

	private IEnumerator _TurretRangeCooldown(float duration)
	{
		yield return new WaitForSeconds(duration);
		_turretInRange = null;
	}
}
