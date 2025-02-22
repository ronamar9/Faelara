using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform objectToFollow;

    private void LateUpdate()
    {
        FollowObject();
    }

    private void FollowObject()
    {
        float posX = objectToFollow.position.x;
        float posY = objectToFollow.position.y;
        float posZ = transform.position.z;

        transform.position = new Vector3(posX, posY, posZ);
    }
}
