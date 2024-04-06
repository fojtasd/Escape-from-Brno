using System;
using System.Collections.Generic;
using UnityEngine;

public class Pooler<T> : IPooler<T> where T : MonoBehaviour, IPoolable
{
	public Pooler(T prefab)
	{
		_Init(prefab);
	}

	public event Action<T> NewInstance;

	public Stack<T> Pool { get; private set; }

	public T Prefab { get; private set; }

	public List<T> UnpooledBuffer { get; private set; }

	public T TryGet(Vector3 position)
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, position, Quaternion.identity); };
		Func<T, T> editStrategy = (instance) => { instance.gameObject.transform.position = position; return instance; };
		return _TryGet(getStrategy, editStrategy);
	}

	public T TryGet()
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, Vector3.zero, Quaternion.identity); };
		Func<T, T> editStrategy = (instance) => { instance.gameObject.transform.position = Vector3.zero; return instance; };
		return _TryGet(getStrategy, editStrategy);
	}

	public T TryGet(Transform parent)
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, parent); };
		Func<T, T> editStrategy = (instance) => {
			instance.gameObject.transform.position = Vector3.zero;
			if ((instance.transform as RectTransform) != null) instance.transform.SetParent(parent, false);
			else instance.transform.parent = parent;
			return instance;
		};
		return _TryGet(getStrategy, editStrategy);
	}


	public T TryGet(Vector3 position, Quaternion rotation)
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, position, rotation); };
		Func<T, T> editStrategy = (instance) => {
			instance.gameObject.transform.SetPositionAndRotation(position, rotation);
			return instance;
		};
		return _TryGet(getStrategy, editStrategy);
	}

	public T TryGet(Vector3 position, Transform parent)
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, position, Quaternion.identity, parent); };
		Func<T, T> editStrategy = (instance) => {
			instance.gameObject.transform.position = position;
			if ((instance.transform as RectTransform) != null) instance.transform.SetParent(parent, false);
			else instance.transform.parent = parent;
			return instance;
		};
		return _TryGet(getStrategy, editStrategy);
	}

	public T TryGet(Vector3 position, Quaternion rotation, Transform parent)
	{
		Func<T> getStrategy = () => { return GameObject.Instantiate(Prefab, position, rotation, parent); };
		Func<T, T> editStrategy = (instance) => {
			instance.gameObject.transform.position = position;
			instance.gameObject.transform.rotation = rotation;
			if ((instance.transform as RectTransform) != null) instance.transform.SetParent(parent, false);
			else instance.transform.parent = parent;
			return instance;
		};
		return _TryGet(getStrategy, editStrategy);
	}

	/// <summary>
	/// Initializes the pooler with the correct prefab.
	/// </summary>
	/// <param name="prefab"></param>
	private void _Init(T prefab)
	{
		Prefab = prefab;
		Pool = new Stack<T>();
		UnpooledBuffer = new List<T>();
	}

	/// <summary>
	/// Adds used poolable back to the pool.
	/// </summary>
	/// <param name="instance"></param>
	private void _Deposit(IPoolable instance)
	{
		T properInstance = instance as T;
		properInstance.gameObject.SetActive(false);
		properInstance.gameObject.transform.position = Vector3.zero;
		Pool.Push(properInstance);
		UnpooledBuffer.Remove(properInstance);
	}

	private T _TryGet(Func<T> getStrategy, Func<T, T> editStrategy)
	{
		if (Pool.Count == 0)
		{
			T instance = getStrategy();
			instance.Recycled = false;
			instance.instanceReturn += _Deposit;
			NewInstance?.Invoke(instance);
			UnpooledBuffer.Add(instance);
			return instance;
		}
		else
		{
			T instance = Pool.Pop();
			UnpooledBuffer.Add(instance);
			instance.Recycled = true;
			instance = editStrategy(instance);
			instance.gameObject.SetActive(true);
			return instance;
		}
	}

	public void ReturnAll()
	{
		List<T> tempList = new List<T>(UnpooledBuffer);
		foreach (var item in tempList)
			item.ReturnInstance();
	}
}
