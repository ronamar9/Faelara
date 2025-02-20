using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10f);
        }
    }

    // Method to update the camera target dynamically
    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
