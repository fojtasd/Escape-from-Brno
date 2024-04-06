using System;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
	public event Action<float> HealthChange;

	public const float MAX_HEALTH = 200f;
	public float Health { get; private set; } = MAX_HEALTH;

	[SerializeField] private float _projectileDamage = 20f;
	[SerializeField] private Player _player;
	[SerializeField] private PlayerStateMachine _playerStateMachine;

	private void Awake()
	{
		_player.PlayerDamageDetector.CollisionWithProjectile += _OnCollisionWithProjectile;
	}

	private void _OnCollisionWithProjectile(Projectile projectile)
	{
		float signedAngle = Vector3.SignedAngle(_player.transform.forward, projectile.transform.forward, _player.transform.up);
		if(Mathf.Abs(signedAngle) > 120 && _playerStateMachine.InCover()) // cover stitem funguje
		{
			Debug.Log("Covered impact!");
			return;
		}

		// jinak me to zrani
		Health = Mathf.Clamp(Health - _projectileDamage, 0f, MAX_HEALTH);
		HealthChange?.Invoke(Health);
	}
}
