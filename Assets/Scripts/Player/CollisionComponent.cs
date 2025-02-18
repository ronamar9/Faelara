using UnityEngine;

public class CollisionComponent : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    public bool onGround;

    private void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

}
