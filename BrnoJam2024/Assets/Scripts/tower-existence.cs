using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform player;

    public int turretHitPoints = 3;
    public float detectionRadius = 10f;
    public float ejectionHeight = 20f;
    public float ejectionSpeed = 5f;

    public bool isAlarmed;
    public bool isAttacking;
    public bool isDamaged; // in the moment of hitting turret

    public enum EjectionState
    {
        Undergroud,
        Above
    }
    private EjectionState _currentEjectionState = EjectionState.Undergroud;
    private Vector3 _originalPosition;


    // Start is called before the first frame update
    void Start()
    {
        isAlarmed = false;
        isAttacking = false;
        isDamaged = false;
        _originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (turretHitPoints <= 0)
        {
            return;
        }
        DetectPlayer();
        React();
    }

    void SetEjectionState(EjectionState newState)
    {
        _currentEjectionState = newState;
        switch (_currentEjectionState)
        {
            case EjectionState.Undergroud:
                transform.position = _originalPosition;
                break;
            case EjectionState.Above:
                isAttacking = true;
                break;
        }
    }

    void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            isAlarmed = true;
        }
        else
        {
            // Player is out of range, deactivate attack mode
            isAlarmed = false;
        }
    }

    void React()
    {
        if (isAlarmed)
        {
            if (_currentEjectionState == EjectionState.Undergroud)
            {
                SetEjectionState(EjectionState.Above);
            }
            else
            {
                // ATTACK!
            }
            Debug.Log("Tower is attacking!");
        }
        else
        {
            if (_currentEjectionState == EjectionState.Above)
            {
                SetEjectionState(EjectionState.Undergroud);
            }
        }

        if (_currentEjectionState == EjectionState.Above)
        {
            // Eject the tower up
            EjectTower();
        }
    }

    public void EjectTower()
    {
        Vector3 targetPosition = _originalPosition + Vector3.up * ejectionHeight;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, ejectionSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            // Tower has finished ejection, do any additional actions here
            Debug.Log("Tower has finished ejection!");
        }
    }

    //fce pro chillovani turrety
    //fce pro prechod turetu do attack modu
    //fce pro
}
