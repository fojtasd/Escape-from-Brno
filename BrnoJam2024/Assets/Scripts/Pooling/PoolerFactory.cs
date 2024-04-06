using UnityEngine;

/// <summary>
/// Factory for dependency inversion
/// </summary>
public class PoolerFactory : MonoBehaviour
{
	static PoolerFactory()
	{
	}

	/// <summary>
	/// Returns an instance of a pooler for spawning a given poolable
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static IPooler<T> GetPooler<T>(T prefab) where T : MonoBehaviour, IPoolable
	{
		return new Pooler<T>(prefab);
	}
}
