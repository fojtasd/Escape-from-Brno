using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCursorController : MonoBehaviour
{

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

	private void OnDestroy()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
