using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject uiObject;
    public void ToggleHint(bool state)
    {
        uiObject.SetActive(state);
    }

}
