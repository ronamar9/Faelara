using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private ShapeType currentShape;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ChangeState(ShapeType newShape)
    {
        if (currentShape == newShape) return;

        Debug.Log($"Switching to {newShape}");
        currentShape = newShape;

        ApplyShapeAbilities(newShape);
    }

    private void ApplyShapeAbilities(ShapeType shape)
    {
        switch (shape)
        {
            case ShapeType.Human:
                Debug.Log("Normal movement enabled.");
                break;
            case ShapeType.Mouse:
                Debug.Log("Sneak ability activated.");
                break;
            case ShapeType.Bear:
                Debug.Log("Bear strength enabled.");
                break;
            case ShapeType.Owl:
                Debug.Log("Flight mode activated.");
                break;
            case ShapeType.Monkey:
                Debug.Log("Rope jumping enabled.");
                break;
        }
    }
}
