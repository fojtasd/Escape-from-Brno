using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collector : MonoBehaviour
{
	public event Action<Collectible> CollectedItem;
	public event Action<Collectible> AfterCollectedItem;

	private void OnTriggerEnter(Collider other)
	{
		Collectible collectible = other.GetComponent<Collectible>();
		if (collectible != null)
		{
			CollectedItem?.Invoke(collectible);
			AfterCollectedItem?.Invoke(collectible);
		}
	}
}