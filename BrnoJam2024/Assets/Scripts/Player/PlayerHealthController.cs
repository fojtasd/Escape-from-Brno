using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealthController : MonoBehaviour
{
	public event Action<float> HealthChange;

	public const float MAX_HEALTH = 200f;
	public float Health { get; private set; } = MAX_HEALTH;

	[SerializeField] private float _projectileDamage = 20f;
	[SerializeField] private Player _player;
	[SerializeField] private PlayerStateMachine _playerStateMachine;

    [SerializeField] private SoundSettings _soundSettings;

    private void Awake()
	{
		_player.PlayerDamageDetector.CollisionWithProjectile += _OnCollisionWithProjectile;
	}

	private void _OnCollisionWithProjectile(Projectile projectile)
	{
		//Vector3 directionToPlayer = (_player.transform.position - projectile.transform.position).normalized;
		float signedAngle = Vector3.SignedAngle(_player.transform.forward, projectile.transform.forward, _player.transform.up);
		Debug.Log(signedAngle + ": " +  _playerStateMachine.InCover().ToString());



		if(Mathf.Abs(signedAngle) >= 130 && _playerStateMachine.InCover()) // cover stitem funguje
		{
			Debug.Log("Covered impact!");
			return;
		}

		// jinak me to zrani
		Health = Mathf.Clamp(Health - _projectileDamage, 0f, MAX_HEALTH);
        PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.playerDostavaDmg[Random.Range(0, _soundSettings.playerDostavaDmg.Length)], 0.25f);
        HealthChange?.Invoke(Health);
	}
}
