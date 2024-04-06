using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlayerDetector : MonoBehaviour
{
    public event Action<bool> PlayerDetectionChange;
    public new String tag = "Player";

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            
            PlayerDetectionChange?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Debug.Log("Player not detected");
            PlayerDetectionChange?.Invoke(false);
        }
    }
}
