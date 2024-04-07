using UnityEngine;

public abstract class Singleton<TInstance> : MonoBehaviour, ISingleton
	where TInstance : class
{
	public static TInstance Instance { get; protected set; }

	public virtual void InitSingleton()
	{
		if ((Instance != null && Instance.ToString() != "null") && Instance != this as TInstance)
		{
			Destroy(gameObject);
		}
		else Instance = this as TInstance;
	}
}