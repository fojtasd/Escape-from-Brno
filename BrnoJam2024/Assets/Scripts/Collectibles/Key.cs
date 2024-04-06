using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectible
{
	public KeyEnum KeyEnum => _key;

	[SerializeField] private KeyEnum _key;
	[SerializeField] private Renderer _renderer;

	private void Awake()
	{
		Color color = Color.white;

		switch(_key)
		{
			case KeyEnum.RED:
				color = Color.red;
				break;
			case KeyEnum.GREEN:
				color = Color.green;
				break;
			case KeyEnum.YELLOW:
				color = Color.yellow;
				break;
		}

		_renderer.material.color = color; 
	}
}
