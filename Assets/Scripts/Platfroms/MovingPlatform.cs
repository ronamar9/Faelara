using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    /// <summary>
    /// Moves the platfrom on X or/and Y Axis depending on the location of a game object indicator
    /// </summary>

    private bool isMovingRight;
    private bool isMovingUp;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject finalPosition;
    private Vector2 currentPosition;
    private Vector2 endPosition;
    private Vector2 startPosition;
    private Vector2 currentXDestination;
    private Vector2 currentYDestination;

    private void Awake()
    {
        startPosition = transform.position;
        currentPosition = transform.position;
        endPosition = finalPosition.transform.position;
        currentXDestination = endPosition;
        currentYDestination = endPosition;
    }

    void Update()
    {
        MovePlatformOnXAxis();
        MovePlatformOnYAxis();
        DetermineFacingDirection();
    }

    private void MovePlatformOnXAxis()
    {
        if (isMovingRight && currentPosition.x < currentXDestination.x)
        {
            currentPosition += Vector2.right * moveSpeed * Time.deltaTime;
            transform.position = currentPosition;

            if (currentPosition.x >= currentXDestination.x)
            {
                currentXDestination = startPosition;
            }
        }

        if (!isMovingRight && currentPosition.x > currentXDestination.x)
        {
            currentPosition += Vector2.left * moveSpeed * Time.deltaTime;
            transform.position = currentPosition;

            if (currentPosition.x <= startPosition.x)
            {
                currentXDestination = endPosition;
            }
        }
    }

    private void MovePlatformOnYAxis()
    {
        if (isMovingUp && currentPosition.y < currentYDestination.y)
        {
            currentPosition += Vector2.up * moveSpeed * Time.deltaTime;
            transform.position = currentPosition;

            if (currentPosition.y >= currentYDestination.y)
            {
                currentYDestination = startPosition;
            }
        }

        if (!isMovingUp && currentPosition.y > currentYDestination.y)
        {
            currentPosition += Vector2.down * moveSpeed * Time.deltaTime;
            transform.position = currentPosition;

            if (currentPosition.y <= startPosition.y)
            {
                currentYDestination = endPosition;
            }
        }
    }

    private void DetermineFacingDirection()
    {
        if (currentPosition.x < currentXDestination.x)
        {
            isMovingRight = true;
        }
        else if (currentPosition.x > currentXDestination.x)
        {
            isMovingRight = false;
        }

        if (currentPosition.y < currentYDestination.y)
        {
            isMovingUp = true;
        }
        else if (currentPosition.y > currentYDestination.y)
        {
            isMovingUp = false;
        }
    }
}
