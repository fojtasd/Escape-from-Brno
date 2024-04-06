using System;
using System.Collections;
using UnityEngine;

public class Poolable : MonoBehaviour, IPoolable
{
	public const float DEFAULT_RETURN_TIME = 30f;
	public event Action<IPoolable> instanceReturn;

	public bool Recycled { get; set; }

	public void ReturnInstance()
	{
		Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
		if (rigidBody != null) rigidBody.velocity = Vector3.zero;
		instanceReturn?.Invoke(this);
	}

	private IEnumerator _ReturnInstanceAfterDurationCoroutine(float duration)
	{
		yield return new WaitForSecondsRealtime(duration);
		ReturnInstance();
	}

	public void ReturnInstanceAfterDuration(float duration = DEFAULT_RETURN_TIME)
	{
		StartCoroutine(_ReturnInstanceAfterDurationCoroutine(duration));
	}
}