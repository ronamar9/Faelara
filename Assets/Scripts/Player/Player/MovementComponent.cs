using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {

        rb.AddForce(new Vector3(direction, 0, 0) * moveSpeed, ForceMode2D.Force);
    }
    public void Jump()
    {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
}
