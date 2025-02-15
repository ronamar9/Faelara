using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour
{
    public int currentShapeIndex;
    public GameObject[] uiElement = new GameObject[4];
    public Color selectedColor;
    public Color disabledColor;
    public Color normalColor;

    private void Start()
    {
        selectedColor = Color.white;
        disabledColor = Color.green;
        normalColor = Color.red;
    }
    public void ChangeHighlightedShape()
    {
        if (uiElement[currentShapeIndex])
        {
        }

    }
}
