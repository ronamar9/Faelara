using UnityEngine;
using UnityEngine.UI;

public class IconSwap : MonoBehaviour
{
    [SerializeField] private Color activeColor;
    [SerializeField] private Color inactiveColor;
    public GameObject[] iconsGameObjects;


    private void Start()
    {
        SetInactive();
    }
    public void SetActive(int index)
    {
        for (int i = 0; i < iconsGameObjects.Length; i++)
        {
            Image image = iconsGameObjects[i].GetComponent<Image>();

            if (i != index)
            {
                image.color = inactiveColor;
            }
            else if (i == index)
            {
                image.color = activeColor;

            }
        }
    }

    public void SetInactive()
    {
        //image.color = inactiveColor;
    }
}
