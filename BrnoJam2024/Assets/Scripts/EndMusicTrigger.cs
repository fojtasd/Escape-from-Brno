using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicTrigger : MonoBehaviour
{
	[SerializeField] private SoundSettings _soundSettings;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			PersistenceManager.Instance.SoundManager.PlayMusicLoop(_soundSettings.spaceOdysseyMusic);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			PersistenceManager.Instance.SoundManager.PlayMusicLoop(_soundSettings.gameMusic);
		}
	}

}
