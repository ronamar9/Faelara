using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public GameObject[] shapes = new GameObject[5];
    public int currentShapeIndex;
    public int currentActiveShape;
    private SpriteRenderer sr;
    private ShapeTypes Shape = ShapeTypes.HumanForm;


    private void Start()
    {
        currentShapeIndex = 0;
        currentActiveShape = currentShapeIndex;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentShapeIndex < shapes.Length-1)
            {
                Debug.Log(currentShapeIndex);
                ChangeCurrentShape(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentShapeIndex > 0)
            {
                Debug.Log(currentShapeIndex);
                ChangeCurrentShape(-1);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShiftShape(ShapeTypes.HumanForm);
        }
    }
    public void ChangeCurrentShape(int direction)
    {
        currentShapeIndex += direction;
    }
    public void ShiftShape(ShapeTypes shape)
    {
        this.Shape = shape;

/*      shapes[currentShapeIndex].SetActive(false);
        currentActiveShape = currentShapeIndex;
        shapes[currentShapeIndex].SetActive(true);
        Debug.Log(currentActiveShape);*/

        //sr.sprite = shapes[currentShapeIndex];
    }

    public void HandleState()
    {
        switch (Shape)
        {
            case ShapeTypes.HumanForm:
                Debug.Log("human");
                break;

            case ShapeTypes.MouseForm:
                Debug.Log("mouse");
                break;

            case ShapeTypes.BearForm:
                Debug.Log("bear");
                break;

            case ShapeTypes.OwlForm:
                Debug.Log("owl");
                break;
        }
    }

}
