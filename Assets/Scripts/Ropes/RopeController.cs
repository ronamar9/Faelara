using UnityEngine;

public class RopeController : MonoBehaviour
{
    private GameObject playerRef;
    private bool isTouchingRope;
    Rigidbody2D playerRb;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {

        if (playerRef != null)
        {
            if (isTouchingRope)
            {
                HangOnRope();
                playerRb.isKinematic = true;
                playerRb.freezeRotation = true;
                Swing(Input.GetAxisRaw("Horizontal"));
                
            }
            else if (!isTouchingRope)
            {
                playerRef.transform.SetParent(null);
                playerRb.isKinematic = false;
            }
        }

    }

    void HangOnRope()
    {
        playerRef.transform.SetParent(this.transform);
        playerRb.transform.position = rb.transform.position;
        playerRb.freezeRotation = true;
        playerRef.transform.rotation = Quaternion.identity;



        if (Input.GetKeyUp(KeyCode.W))
        {
            JumpFromRope(playerRb.velocity.x);
        }

    }


    public void Swing(float HorizontalInput)
    {
        rb.AddForce(new Vector2(HorizontalInput * 3 * Time.deltaTime, 0),ForceMode2D.Impulse);
    }

    public void JumpFromRope(float direction)
    {
        //playerRb.position = new Vector2(rb.transform.position.x + direction, playerRb.position.y * 2);
        playerRb.AddForce(new Vector2(direction * 3, 3), ForceMode2D.Impulse);
        isTouchingRope = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monkey"))
        {
            playerRef = other.gameObject;
            playerRb = playerRef.GetComponent<Rigidbody2D>();
            isTouchingRope = true;
            Debug.Log("touching Rope!");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monkey"))
        {
            playerRef = this.gameObject;
            playerRb = playerRef.GetComponent<Rigidbody2D>();
            isTouchingRope = false;
        }
    }
}
