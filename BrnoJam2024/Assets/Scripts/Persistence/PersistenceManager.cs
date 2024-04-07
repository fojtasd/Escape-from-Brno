using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
	public static PersistenceManager Instance { get; private set; }

	[SerializeField] private SceneHandler _sceneHandler;
	[SerializeField] private SoundManager _soundManager;

	public SceneHandler SceneHandler => _sceneHandler;
	public SoundManager SoundManager => _soundManager;

	private void Awake()
	{
		// If there is an instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
	}
}
