using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform player;
    public GameObject TurretObject;

    public float speed = 1f;

    public bool isAttacking;
    public bool isPlayerDetected;

    public Transform _originalPosition;
    public Transform _target;

    public TurretPlayerDetector _detector;

    private Coroutine ejectionCoroutine;
    private Coroutine deEjectionCoroutine;

    private void Awake()
    {
        _detector.PlayerDetectionChange += OnPlayerDetectionChange;
    }

    private void OnPlayerDetectionChange(bool isPlayerDetected)
    {
        this.isPlayerDetected = isPlayerDetected;
        if (isPlayerDetected)
        {
            Debug.Log("Player detected");
            if (ejectionCoroutine == null)
            {
                PerformEjectionUp();
            }
        } else
        {
            Debug.Log("Not detected");
            if (ejectionCoroutine == null)
            {
                PerformEjectionDown();
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PerformEjectionUp()
    {
        ejectionCoroutine = StartCoroutine(EjectCoroutine());
    }

    IEnumerator EjectCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < speed)
        {
            TurretObject.transform.position = Vector3.Lerp(_originalPosition.position, _target.position, elapsedTime / speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ejectionCoroutine = null;
        if (!isPlayerDetected)
        {
            deEjectionCoroutine = StartCoroutine(DeEjectCoroutine());
        }
    }

    void PerformEjectionDown()
    {
        deEjectionCoroutine = StartCoroutine(DeEjectCoroutine());
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

        deEjectionCoroutine = null;
        if (isPlayerDetected)
        {
            ejectionCoroutine = StartCoroutine(EjectCoroutine());
        }
    }

}
