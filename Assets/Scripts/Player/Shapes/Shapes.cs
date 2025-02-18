using UnityEngine;

[CreateAssetMenu(fileName = "Shape", menuName = "Shapes/New Shape", order = 1)]
public class Shapes : ScriptableObject
{
    public Sprite sprite;
    public float moveSpeed;
    public RuntimeAnimatorController animatorController;
    public bool canFly;

    // Collider properties
    public Vector2 colliderSize;
    public Vector2 colliderOffset;
}
