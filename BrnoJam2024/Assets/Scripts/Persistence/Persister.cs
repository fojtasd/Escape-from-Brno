public abstract class Persister<TType> : Singleton<TType>
	where TType : class
{
	protected virtual void _BeforeDestroy() { }

	public override void InitSingleton()
	{
		if (Instance != null)
		{
			_BeforeDestroy();
			Destroy(gameObject);
		}
		else
		{
			Instance = this as TType;
			DontDestroyOnLoad(this);
		}
	}
}
