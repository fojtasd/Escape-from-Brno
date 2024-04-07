using UnityEngine;

public class SoundManager : MonoBehaviour
{
	[SerializeField] private AudioSource _musicSource;
	[SerializeField] private AudioSource _soundSource;
	[SerializeField] private AudioSource _soundAltSource;

	public void PlayMusicLoop(AudioClip clip)
	{
		if (_musicSource == null)
			return;

		_musicSource.Stop();
		_musicSource.clip = clip;
		_musicSource.loop = true;
		 if(!_musicSource.isPlaying) _musicSource.Play();
	}

	public void PlaySoundLoop(AudioClip clip)
	{
		if(_soundSource == null)
			return;

		_soundSource.loop = true;
		_PlaySound(clip, _soundSource);
	}

	public void PlaySoundOnce(AudioClip clip)
	{
		//_soundSource.Stop();
		_soundSource.PlayOneShot(clip);
	}

	public void PlayAltSoundOnce(AudioClip clip)
	{
		_soundAltSource.PlayOneShot(clip);
	}

	private void _PlaySound(AudioClip clip, AudioSource source)
	{
		if (source.clip != clip)
			source.clip = clip;

		if (!source.isPlaying)
			source.Play();
	}

	public void StopSound()
	{
		_soundSource?.Stop();
	}
}
