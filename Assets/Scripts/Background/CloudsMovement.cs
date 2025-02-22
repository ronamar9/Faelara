using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    private float moveSpeed;
    private int screenEdge = 20;
    private CloudManager cloudManager;
    private bool hasSpawned = false;

    private void Start()
    {
        moveSpeed = Random.Range(0.2f, 0.6f);
        cloudManager = GetComponentInParent<CloudManager>();
    }

    private void Update()
    {
        transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;

        if (transform.localPosition.x >= screenEdge)
        {
            DestroyCloud();
        }
    }

    public void DestroyCloud()
    {
        Destroy(this.gameObject);
    }
}
