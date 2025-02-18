using UnityEngine;
using UnityEngine.Events;

public class ShapeShift : MonoBehaviour
{
    public int currentShapeIndex;
    public int currentActiveShape;
    private SpriteRenderer sr;
    public Shapes normalshape;
    public Shapes[] shapes = new Shapes[4];
    private Animator animator;
    private BoxCollider2D myCollider;
    public UnityEvent changeShape;
    private void Start()
    {
        currentShapeIndex = 0;
        currentActiveShape = currentShapeIndex;
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sr.sprite = shapes[currentShapeIndex].sprite;
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentShapeIndex < shapes.Length - 1)
        {
            ChangeCurrentShape(1);
            print(currentShapeIndex);
        }
        if (Input.GetKeyDown(KeyCode.Q) && currentShapeIndex > 0)
        {
            ChangeCurrentShape(-1);
            print(currentShapeIndex);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShiftShape(currentShapeIndex);
        }
    }
    public void ChangeCurrentShape(int direction)
    {
        currentShapeIndex += direction;
        changeShape.Invoke();
    }
    public void ShiftShape(int shape)
    {
/*        myCollider.offset = shapes[shape].colliderOffset;
        myCollider.size = shapes[shape].colliderSize;*/
        sr.sprite = shapes[shape].sprite;
        animator.runtimeAnimatorController = shapes[shape].animatorController;
    }

}
