using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pooler - its mission is to recycle objects to limit redundant memory work (creating and destroying GameObjects)
/// </summary>
public interface IPooler<T> where T : IPoolable
{
	/// <summary>
	/// Sends out a newly created instance from the pooler.
	/// </summary>
	event Action<T> NewInstance;

	/// <summary>
	/// Prefab, from which a new object instance can be created, if there is none left in the pool
	/// </summary>
	T Prefab { get; }

	/// <summary>
	/// Pool that contains the poolable instances
	/// </summary>
	Stack<T> Pool { get; }

	List<T> UnpooledBuffer { get; }

	/// <summary>
	/// Tries to get an instance from the pooler and if it can't, creates a new instance
	/// </summary>
	/// <returns></returns>
	T TryGet();

	T TryGet(Transform parent);

	/// <summary>
	/// Tries to get an instance from the pooler and if it can't, creates a new instance
	/// </summary>
	/// <param name="position"></param>
	/// <returns></returns>
	T TryGet(Vector3 position);

	/// <summary>
	/// Tries to get an instance from the pooler and if it can't, creates a new instance
	/// </summary>
	/// <param name="position"></param>
	/// <param name="rotation"></param>
	/// <returns></returns>
	T TryGet(Vector3 position, Quaternion rotation);

	T TryGet(Vector3 position, Transform parent);

	T TryGet(Vector3 position, Quaternion rotation, Transform _parent);

	/// <summary>
	/// Returns all instances in the pool to yhe pooler
	/// </summary>
	void ReturnAll();
}