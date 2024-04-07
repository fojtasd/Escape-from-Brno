using FMOD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Turret : MonoBehaviour
{
	public const float MAX_HEALTH = 100f;
	public bool CanShoot => _isPlayerDetected;
	public float Health { get; private set; } = MAX_HEALTH;

	public Transform player;
	public GameObject TurretObject;

	public float speed = 1f;

	private bool _isPlayerDetected;

	public Transform _originalPosition;
	public Transform _target;

	public TurretPlayerDetector _detector;

	private Coroutine _ejectionCoroutine;
	private Coroutine _deEjectionCoroutine;

	[SerializeField] private SoundSettings _soundSettings;

	private void Awake()
	{
		_detector.PlayerDetectionChange += OnPlayerDetectionChange;
	}

	public void Damage(float damage)
	{
		Health = Mathf.Clamp(Health - damage, 0f, MAX_HEALTH);
		PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.poskozeniTurretu);
		if (Health == 0f)
		{
			StopAllCoroutines();
			gameObject.SetActive(false);

			PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.rozpadTurretu);
		}
	}

	private void OnPlayerDetectionChange(bool isPlayerDetected)
	{
		this._isPlayerDetected = isPlayerDetected;
		if (isPlayerDetected)
		{
			//Debug.Log("Player detected");
			if (_ejectionCoroutine == null)
			{
				PerformEjectionUp();
			}
		}
		else
		{
			//Debug.Log("Not detected");
			if (_deEjectionCoroutine == null)
			{
				PerformEjectionDown();
			}

		}
	}

	void PerformEjectionUp()
	{
		_ejectionCoroutine = StartCoroutine(EjectCoroutine());
	}

	IEnumerator EjectCoroutine()
	{

		PersistenceManager.Instance.SoundManager.PlaySoundOnce(_soundSettings.startTurretu);

		float elapsedTime = 0f;
		while (elapsedTime < speed)
		{
			TurretObject.transform.position = Vector3.Lerp(_originalPosition.position, _target.position, elapsedTime / speed);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		_ejectionCoroutine = null;
		if (!_isPlayerDetected)
		{
			_deEjectionCoroutine = StartCoroutine(DeEjectCoroutine());
		}
	}

	void PerformEjectionDown()
	{
		_deEjectionCoroutine = StartCoroutine(DeEjectCoroutine());
	}
	IEnumerator DeEjectCoroutine()
	{
		float elapsedTime = 0f;
		while (elapsedTime < speed)
		{
			TurretObject.transform.position = Vector3.Lerp(_target.position, _originalPosition.position, elapsedTime / speed);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		_deEjectionCoroutine = null;
		if (_isPlayerDetected)
		{
			_ejectionCoroutine = StartCoroutine(EjectCoroutine());
		}
	}

}
