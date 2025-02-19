using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public int currentShapeIndex;
    public int currentActiveShape;
    public UnityEvent changeShape;
    public ShapeType[] shapes = new ShapeType[5];
    public GameObject[] shapeObjects;

    private void Start()
    {
        currentShapeIndex = 0;
        currentActiveShape = currentShapeIndex;

        ToggleShape(currentActiveShape);
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
        currentShapeIndex = Mathf.Clamp(currentShapeIndex, 0, shapes.Length - 1);
        changeShape.Invoke();
    }

    public void ShiftShape(int shapeIndex)
    {
        if (currentActiveShape == shapeIndex) return;

        GameManager.Instance.ChangeState(shapes[shapeIndex]);
        ToggleShape(shapeIndex);
        currentActiveShape = shapeIndex;
    }

    private void ToggleShape(int activeIndex)
    {
        for (int i = 0; i < shapeObjects.Length; i++)
        {
            shapeObjects[i].SetActive(i == activeIndex);
        }
    }
}
