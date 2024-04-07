using UnityEngine;

[CreateAssetMenu(fileName = "newSoundSettings", menuName ="Sound/Settings")]
public class SoundSettings : ScriptableObject
{
	// music
	public AudioClip menuMusic;
	public AudioClip victoryMusic;
	public AudioClip defeatMusic;
	public AudioClip gameMusic;
}
