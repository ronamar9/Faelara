using UnityEngine;

public class CollisionComponent : MonoBehaviour
{
    private CapsuleCollider2D playerCollider;
    public bool onGround;
    private GameObject collisionRef;

    private void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (collisionRef != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                collisionRef.GetComponent<Rock>().GetDamage();
                Debug.Log("bear crush");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (collision.gameObject.CompareTag("Rock") && this.gameObject.CompareTag("Bear"))
        {
            collisionRef = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }

        if (collision.gameObject.CompareTag("Rock") && this.gameObject.CompareTag("Bear"))
        {
            collisionRef = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

}
