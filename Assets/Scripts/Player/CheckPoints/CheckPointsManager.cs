using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    /// <summary>
    /// Manages what is the current checkpoint that the player respawns at upon death. Changes the current checkpoint when collides with a new checkpoint.
    /// </summary>

    private Vector2 startPosition;
    private Vector2 currentCheckPoint;

    public Vector2 SetStartPoint(Vector2 startPoint)
    {
        startPosition = startPoint;
        return startPosition;
    }

    public Vector2 GetRestartPoint()
    {
        return startPosition;
    }

    public Vector2 SetCheckPoint(Vector2 checkPoint)
    {
        currentCheckPoint = checkPoint;
        return checkPoint;
    }

    public Vector2 GetCurrentCheckPoint()
    {
        return currentCheckPoint;
    }

}
