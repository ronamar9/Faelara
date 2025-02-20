using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public int currentShapeIndex;
    public int currentActiveShape;
    public UnityEvent changeShape;

    public GameObject defaultShape;
    public ShapeType[] shapes;
    public GameObject[] shapeObjects;

    private Vector3 lastPosition;
    private PlayerController playerController; // Reference to PlayerController

    private void Start()
    {
        playerController = GetComponent<PlayerController>(); // Find PlayerController

        currentShapeIndex = 0;
        currentActiveShape = -1;

        lastPosition = defaultShape.transform.position;
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

        lastPosition = defaultShape.activeSelf ? defaultShape.transform.position : shapeObjects[currentActiveShape].transform.position;

        GameManager.Instance.ChangeState(shapes[shapeIndex]);
        ToggleShape(shapeIndex);
        currentActiveShape = shapeIndex;

        // Update the player's collision reference
        playerController.UpdateCollisionComponent(shapeObjects[currentActiveShape].GetComponent<CollisionComponent>());
    }

    private void ToggleShape(int activeIndex)
    {
        if (activeIndex == -1)
        {
            defaultShape.SetActive(true);
            defaultShape.transform.position = lastPosition;

            foreach (GameObject shape in shapeObjects)
            {
                shape.SetActive(false);
            }

            playerController.UpdateCollisionComponent(defaultShape.GetComponent<CollisionComponent>());
        }
        else
        {
            defaultShape.SetActive(false);

            for (int i = 0; i < shapeObjects.Length; i++)
            {
                shapeObjects[i].SetActive(i == activeIndex);
                if (shapeObjects[i].activeSelf)
                {
                    shapeObjects[i].transform.position = lastPosition;
                }
            }

            playerController.UpdateCollisionComponent(shapeObjects[activeIndex].GetComponent<CollisionComponent>());
        }
    }
}
