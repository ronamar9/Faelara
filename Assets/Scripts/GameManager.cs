using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private ShapeTypes currentShape;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ChangeState(ShapeTypes newShape)
    {
        if (currentShape == newShape) return;

        Debug.Log($"Switching to {newShape}");
        currentShape = newShape;

        ApplyShapeAbilities(newShape);
    }

    private void ApplyShapeAbilities(ShapeTypes shape)
    {
        switch (shape)
        {
            case ShapeTypes.Human:
                Debug.Log("Normal movement enabled.");
                break;
            case ShapeTypes.Mouse:
                Debug.Log("Sneak ability activated.");
                break;
            case ShapeTypes.Bear:
                Debug.Log("Bear strength enabled.");
                break;
            case ShapeTypes.Owl:
                Debug.Log("Flight mode activated.");
                break;
            case ShapeTypes.Monkey:
                Debug.Log("Rope jumping enabled.");
                break;
        }
    }
}
