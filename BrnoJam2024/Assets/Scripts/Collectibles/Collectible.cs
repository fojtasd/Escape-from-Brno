using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
	public Collider Collider => _collider;

	[SerializeField] protected Collider _collider;

}

