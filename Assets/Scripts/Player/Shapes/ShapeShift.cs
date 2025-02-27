using System;
using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public int currentShapeIndex;
    public int currentActiveShape;

    private int defaultShapeIndex = 0;
    public ShapeTypes[] shapes;
    public GameObject[] shapeObjects;

    private Vector3 lastPosition;
    private PlayerController playerController;
    private CameraFollow cameraFollow;

    [SerializeField] private GameObject shapeShiftEffect;

    public UnityEvent[] changeShape;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        currentShapeIndex = defaultShapeIndex;
        currentActiveShape = defaultShapeIndex;

        lastPosition = shapeObjects[defaultShapeIndex].transform.position;
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
            if (currentShapeIndex == defaultShapeIndex)
            {
                ShiftShape(0);
            }
            else
            {
                ShiftShape(currentShapeIndex);
            }
        }

        if (playerController.mana.currentAmount <= 0 || Input.GetKeyDown(KeyCode.Tab))
        {
            ShiftShape(defaultShapeIndex);
        }

    }

    public void ChangeCurrentShape(int direction)
    {
        currentShapeIndex += direction;
        currentShapeIndex = Mathf.Clamp(currentShapeIndex, 0, shapes.Length - 1);
        changeShape[currentShapeIndex].Invoke();
    }

    public void ShiftShape(int shapeIndex)
    {
        if (currentActiveShape == shapeIndex) return;

        lastPosition = shapeObjects[defaultShapeIndex].activeSelf ? shapeObjects[defaultShapeIndex].transform.position : shapeObjects[currentActiveShape].transform.position;

        GameManager.Instance.ChangeState(shapes[shapeIndex]);
        ToggleShape(shapeIndex);
        currentActiveShape = shapeIndex;

        cameraFollow.UpdateTarget(shapeObjects[currentActiveShape].transform);

        Instantiate(shapeShiftEffect, shapeObjects[currentActiveShape].transform);
    }

    private void ToggleShape(int activeIndex)
    {
        for (int i = 0; i < shapeObjects.Length; i++)
        {
            shapeObjects[i].SetActive(i == activeIndex);

            if (shapeObjects[i].activeSelf)
            {
                shapeObjects[i].transform.position = lastPosition;
            }
        }

        if (activeIndex == defaultShapeIndex)
        {
            shapeObjects[defaultShapeIndex].SetActive(true);
        }

        cameraFollow.UpdateTarget(shapeObjects[activeIndex].transform);
    }

}
