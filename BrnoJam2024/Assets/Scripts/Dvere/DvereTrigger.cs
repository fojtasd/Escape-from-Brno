using System;
using UnityEngine;

public class DvereTrigger : MonoBehaviour
{
	public event Action<Player> PlayerInTrigger;
	public event Action<Player> PlayerOutsideTrigger;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			PlayerInTrigger?.Invoke(other.GetComponentInParent<Player>());
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			PlayerOutsideTrigger?.Invoke(other.GetComponentInParent<Player>());
		}
	}
}
