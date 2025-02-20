using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private CollisionComponent collisionComponent;
    public bool isFlying;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionComponent = GetComponent<CollisionComponent>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Move(Input.GetAxisRaw("Horizontal"));
        }

        if (collisionComponent.onGround && !isFlying)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Jump();
            }
        }
        if (isFlying)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Fly();
            }
        }
    }

    public void Move(float direction)
    {

        rb.AddForce(new Vector3(direction, 0, 0) * moveSpeed, ForceMode2D.Force);
    }
    public void Jump()
    {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
    public void Fly()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
}
