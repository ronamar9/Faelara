using Unity.VisualScripting;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour
{
    /// <summary>
    /// Gets the current startPosition and currentCheckPoint for the current played character and saves it in CheckPointManager which sits at the parent ("Player").
    /// </summary>

    public CheckPointsManager cpm;
    private Vector2 startPosition;
    private Vector2 restartPosition;

    void Start()
    {
        startPosition = transform.TransformPoint(Vector2.zero); // This code coverts the character's position compared to the world and not the parent.
        cpm.SetStartPoint(startPosition);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5)) // reset the level to startposition.
        {
            restartPosition = cpm.GetRestartPoint();
            transform.position = restartPosition;
            Debug.Log("Restart");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) // If collided with checkpoint, update the current checkpoint.
    {
        if (collider.gameObject.CompareTag("CheckPoint"))
        {
            cpm.SetCheckPoint(transform.position);
            Animator animator = collider.GetComponent<Animator>();
            animator.SetBool("isChecked", true);
            
        }
    }
    /// <summary>
    /// If current character collides with outofbounds reset the position to the current checkpoint. if didn't reach checkpoint, reset to startposition.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            if (cpm.GetCurrentCheckPoint() != Vector2.zero)
            {
                transform.position = cpm.GetCurrentCheckPoint();
            }
            else
            {
                transform.position = cpm.GetRestartPoint();
            }
        }
    }
}
