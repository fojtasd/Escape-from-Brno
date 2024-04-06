using System;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
	public event Action<float> HealthChange;

	public const float MAX_HEALTH = 200f;
	public float Health { get; private set; } = MAX_HEALTH;

	[SerializeField] private float _projectileDamage = 20f;
	[SerializeField] private Player _player;

	private void Awake()
	{
		_player.PlayerDamageDetector.CollisionWithProjectile += _OnCollisionWithProjectile;
	}

	private void _OnCollisionWithProjectile()
	{
		Health = Mathf.Clamp(Health - _projectileDamage, 0f, MAX_HEALTH);
		HealthChange?.Invoke(Health);
	}
}
