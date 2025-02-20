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
                //movement.isFlying = false;
                break;
            case ShapeType.Mouse:
                Debug.Log("Sneak ability activated.");
                //movement.isFlying = false;
                break;
            case ShapeType.Bear:
                Debug.Log("Bear strength enabled.");
                //movement.isFlying = false;
                break;
            case ShapeType.Owl:
                Debug.Log("Flight mode activated.");
                //movement.isFlying = true;
                break;
            case ShapeType.Monkey:
                Debug.Log("Rope jumping enabled.");
                //movement.isFlying = false;
                break;
        }
    }
}
