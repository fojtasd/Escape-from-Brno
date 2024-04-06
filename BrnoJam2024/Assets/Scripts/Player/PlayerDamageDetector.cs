using System;
using UnityEngine;

public class PlayerDamageDetector : MonoBehaviour
{
	public event Action<Projectile> CollisionWithProjectile;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Projectile"))
		{
			CollisionWithProjectile?.Invoke(collision.collider.GetComponent<Projectile>());
		}
	}

}
