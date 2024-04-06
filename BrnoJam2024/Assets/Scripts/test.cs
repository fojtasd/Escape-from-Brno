using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float detectionRadius = 10f; // Radius within which the tower detects the player
    public float ejectionHeight = 5f; // Height to which the tower is ejected when attacking
    public float ejectionSpeed = 5f; // Speed at which the tower rises when attacking
    private Vector3 originalPosition; // Original position of the tower when not attacking

    // Enum for the ejection states
    public enum EjectionState
    {
        Underground,
        AboveGround
    }
    private EjectionState currentEjectionState = EjectionState.Underground; // Initial ejection state

    void Start()
    {
        originalPosition = transform.position; // Store the original position of the tower
    }

    void Update()
    {
        // Check if the player is within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Player is within range, enter attack mode
            SetEjectionState(EjectionState.AboveGround);
        }
        else
        {
            // Player is out of range, deactivate attack mode
            SetEjectionState(EjectionState.Underground);
        }

        // If tower is attacking, perform attack actions
        if (currentEjectionState == EjectionState.AboveGround)
        {
            // Eject the tower up
            EjectTower();
        }
    }

    void SetEjectionState(EjectionState newState)
    {
        // Update the ejection state
        currentEjectionState = newState;

        // Perform actions based on the new ejection state
        switch (currentEjectionState)
        {
            case EjectionState.Underground:
                transform.position = originalPosition; // Reset tower position to original position
                break;
            case EjectionState.AboveGround:
                // No action needed here, tower will be ejected in Update() function
                break;
        }
    }

    void EjectTower()
    {
        // Calculate the target position to eject the tower to
        Vector3 targetPosition = originalPosition + Vector3.up * ejectionHeight;

        // Move the tower towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, ejectionSpeed * Time.deltaTime);

        // If the tower reaches the target position, stop ejection
        if (transform.position == targetPosition)
        {
            // Tower has finished ejection, do any additional actions here
            Debug.Log("Tower has finished ejection!");
        }
    }
}
