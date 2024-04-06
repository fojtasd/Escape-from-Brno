using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Poolable
{
	public Rigidbody Rigidbody => _rigidbody;

	[SerializeField] private Rigidbody _rigidbody;

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			ReturnInstance();
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		
	}
}
