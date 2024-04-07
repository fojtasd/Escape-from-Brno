using UnityEngine;

public class RollingCredits : MonoBehaviour
{
    public float scrollSpeed = 150f;

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}