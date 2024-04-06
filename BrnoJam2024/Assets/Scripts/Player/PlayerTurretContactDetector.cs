using System;
using UnityEngine;

public class PlayerTurretContactDetector : MonoBehaviour
{
	public event Action<Turret> CollisionWithTurret;
	public event Action<Turret> EndCollisionWithTurret;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Turret"))
		{
			CollisionWithTurret?.Invoke(collision.collider.GetComponentInParent<Turret>());
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.CompareTag("Turret"))
		{
			EndCollisionWithTurret?.Invoke(collision.collider.GetComponentInParent<Turret>());
		}
	}

}
