using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public int currentShapeIndex; // Tracks selected shape
    public int currentActiveShape; // Tracks active shape
    public UnityEvent changeShape;
    public ShapeType[] shapes = new ShapeType[5];
    public GameObject[] shapeObjects; // Array to hold shape GameObjects

    private void Start()
    {
        currentShapeIndex = 0;
        currentActiveShape = currentShapeIndex;

        ToggleShape(currentActiveShape); // Activate default shape at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeCurrentShape(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeCurrentShape(-1);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShiftShape(currentShapeIndex);
        }
    }

    public void ChangeCurrentShape(int direction)
    {
        currentShapeIndex += direction;
        currentShapeIndex = Mathf.Clamp(currentShapeIndex, 0, shapes.Length - 1); // Prevent out-of-bounds
        changeShape.Invoke();
    }

    public void ShiftShape(int shapeIndex)
    {
        if (currentActiveShape == shapeIndex) return; // Prevent redundant transformations

        GameManager.Instance.ChangeState(shapes[shapeIndex]); // Update GameManager state
        ToggleShape(shapeIndex); // Enable the new shape and disable the others
        currentActiveShape = shapeIndex;
    }

    private void ToggleShape(int activeIndex)
    {
        for (int i = 0; i < shapeObjects.Length; i++)
        {
            shapeObjects[i].SetActive(i == activeIndex); // Activate selected shape, deactivate others
        }
    }
}
