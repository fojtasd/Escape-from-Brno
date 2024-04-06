using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
	[Range(0.01f, 1f)]
	[SerializeField] private float _cameraAdjustRate = 0.15f;
	[Range(100f,5000f)]
	[SerializeField] private float _rotateCameraSpeed = 500f;
	[SerializeField] private Player _player;
	[SerializeField] private Camera _camera;

	private Vector3 _rotation = Vector3.zero;

	private void Awake()
	{
		_camera.transform.position = _player.CameraPosition.position;
	}

	private void Update()
	{
		float mouseX = Input.GetAxis("Mouse X");
		if(mouseX != 0)
		{
			_rotation.y = mouseX;
			_player.transform.Rotate(_rotation * Time.deltaTime * _rotateCameraSpeed);
		}
		else _rotation.y = 0;
	}

	private void LateUpdate()
	{
		_camera.transform.position = Vector3.Lerp(_camera.transform.position, _player.CameraPosition.position, _cameraAdjustRate);
		_camera.transform.rotation = _player.transform.rotation;
	}
}
