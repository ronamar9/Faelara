using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.A))
        {
            Move(UnityEngine.Input.GetAxisRaw("Horizontal"));
        }
        
        if (UnityEngine.Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    private void Move(float direction)
    {

        rb.AddForce(new Vector3(direction, 0, 0) * moveSpeed, ForceMode2D.Force);
    }
    private void Jump()
    {
        rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
    }
}