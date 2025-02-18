using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0, 0, -10);

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -10f);
    }
}
