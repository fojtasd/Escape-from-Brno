using UnityEngine;

[CreateAssetMenu(fileName = "newSoundSettings", menuName ="Sound/Settings")]
public class SoundSettings : ScriptableObject
{
	// music
	public AudioClip menuMusic;
	public AudioClip victoryMusic;
	public AudioClip defeatMusic;
	public AudioClip gameMusic;

	public AudioClip spaceOdysseyMusic;

	// sound
	public AudioClip[] swingClips;
	public AudioClip[] turretShootClips;
	public AudioClip[] footSteps;
	public AudioClip rozpadTurretu;
	public AudioClip startTurretu;
	public AudioClip poskozeniTurretu;
	public AudioClip[] playerDostavaDmg;
}
