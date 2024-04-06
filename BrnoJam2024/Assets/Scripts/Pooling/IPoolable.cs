using System;
using System.Collections;

/// <summary>
/// Interface of a base object that can be recycled in a pool
/// </summary>
public interface IPoolable
{
	/// <summary>
	/// Causes a return of this object into the original pool
	/// </summary>
	event Action<IPoolable> instanceReturn;

	/// <summary>
	/// Indicates, whether this instance was already recycled
	/// </summary>
	bool Recycled { get; set; }

	/// <summary>
	/// Returns this instance into pool
	/// </summary>
	void ReturnInstance();

	/// <summary>
	/// Returns this instance into pool after time elapsed
	/// </summary>
	/// <param name="duration"></param>
	/// <returns></returns>
	void ReturnInstanceAfterDuration(float duration);
}