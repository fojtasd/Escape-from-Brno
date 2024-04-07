using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
	[SerializeField] private Canvas _LoadScreen;
	[SerializeField] private Image _ProgressBar;
	[SerializeField] private SceneHandler _SceneHandler;

	private void Awake()
	{
		_SceneHandler.loadBegin += _OnLoadBegin;
		_SceneHandler.loadEnd += _OnLoadEnd;
		_SceneHandler.loadProgress += _OnLoadProgress;
		_LoadScreen.gameObject.SetActive(false);
	}

	private void _OnLoadProgress(object sender, float progress)
	{
		_ProgressBar.rectTransform.localScale = new Vector2(progress,1f);
	}

	private void _OnLoadEnd(object sender, EventArgs e)
	{
		_LoadScreen.gameObject.SetActive(false);
	}

	private void _OnLoadBegin(object sender, EventArgs e)
	{
		_LoadScreen.gameObject.SetActive(true);
	}
}
