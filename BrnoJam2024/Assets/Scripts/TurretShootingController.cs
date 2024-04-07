using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootingController : MonoBehaviour
{

	[SerializeField] private Projectile _projectilePrefab;
	[SerializeField] private float _cooldownDuration = 1f;
	[SerializeField] private float _projectileSpeed = 150f;
	[SerializeField] private float _recycleDuration = 10f;
	[SerializeField] private Transform _shootingOrigin;
	[SerializeField] private Turret _turret;
	[SerializeField] private SoundSettings _soundSettings;

	private float _shootCooldown = 0f;
	private IPooler<Projectile> _projectilePooler;

	private void Awake()
	{
		_projectilePooler = PoolerFactory.GetPooler(_projectilePrefab);
	}

	private void Update()
	{
		if(_turret.CanShoot)
		{
			//Debug.Log(_shootCooldown);
			if (_shootCooldown > _cooldownDuration)
			{
				_Shoot();
				_shootCooldown = 0f;
			}
			else _shootCooldown += Time.deltaTime;
		}
	}

	private void _Shoot()
	{
		PersistenceManager.Instance.SoundManager.PlayAltSoundOnce(_soundSettings.turretShootClips[Random.Range(0, _soundSettings.turretShootClips.Length)], 0.5f);
		Projectile projectile = _projectilePooler.TryGet(_shootingOrigin.position, Quaternion.identity, _shootingOrigin);
		projectile.ReturnInstanceAfterDuration(_recycleDuration);
		projectile.Rigidbody.velocity = Vector3.zero;
		projectile.Rigidbody.angularVelocity = Vector3.zero;

		projectile.Rigidbody.AddForce(_shootingOrigin.forward * _projectileSpeed);
	}
}
