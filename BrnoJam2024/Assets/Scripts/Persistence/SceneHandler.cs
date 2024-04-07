using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
	/// <summary>
	/// This event marks the beginning of scene loading.
	/// </summary>
	public event EventHandler loadBegin;

	/// <summary>
	/// This event marks the end of scene loading.
	/// </summary>
	public event EventHandler loadEnd;

	/// <summary>
	/// Sends out the progress of scene loading between 0 1nd 1.
	/// </summary>
	public event EventHandler<float> loadProgress;

	[SerializeField] private SoundSettings _soundSettings;
	[SerializeField] private SoundManager _soundManager;

	private void Start()
	{
		SceneManager.sceneLoaded += _OnActiveSceneChanged;
		Scene activeScene = SceneManager.GetActiveScene();
		_OnActiveSceneChanged(activeScene, LoadSceneMode.Single);
	}

	private void _OnActiveSceneChanged(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Game")
		{
			_soundManager?.PlayMusicLoop(_soundSettings.gameMusic);
		}
		else if (scene.name == "MainMenu")
		{
			_soundManager?.PlayMusicLoop(_soundSettings.menuMusic);
		}
		else if (scene.name == "DefeatScreen")
		{
			_soundManager?.PlayMusicLoop(_soundSettings.defeatMusic);
		}
		else if (scene.name == "VictoryScreen")
		{
			_soundManager?.PlayMusicLoop(_soundSettings.victoryMusic);
		}
	}

	/// <summary>
	/// Changes and loads a scene to the scene with 'sceneName' name.
	/// </summary>
	/// <param name="sceneName">Name of the loaded scene</param>
	public void ChangeScene([SerializeField] string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// Load a scene asynchronously. Uses load screen to show progress.
	/// </summary>
	/// <param name="sceneName"></param>
	public void ChangeSceneAsync([SerializeField] string sceneName)
	{
		AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
		StartCoroutine(_LoadSceneCoroutine(loadOperation));
	}

	/// <summary>
	/// Quits the game/application
	/// </summary>
	public void QuitGame()
	{
		Application.Quit();
	}

	private IEnumerator _LoadSceneCoroutine(AsyncOperation loadOperation)
	{
		loadBegin?.Invoke(this, EventArgs.Empty);
		while (!loadOperation.isDone)
		{
			loadProgress?.Invoke(this, loadOperation.progress * (1 / 0.9f));
			yield return null;
		}
		loadEnd?.Invoke(this, EventArgs.Empty);
	}
}
