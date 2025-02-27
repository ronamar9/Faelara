using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private CollisionComponent collisionComponent;
    private ShapeShift shapeShiftComponent;
    public Stats mana;
    public Slider manaBar;
    public bool Shapeshifting;
    private void Start()
    {
        movementComponent = GetComponentInChildren<MovementComponent>();
        shapeShiftComponent = GetComponent<ShapeShift>();
        collisionComponent = GetComponentInChildren<CollisionComponent>();

        mana = new Stats("Mana", 100f, 80f);
        manaBar.maxValue = mana.maxAmount;
        manaBar.value = mana.currentAmount;
    }

    private void Update()
    {
        if (!Shapeshifting)
        {
            if (mana.currentAmount < mana.maxAmount)
            {
                mana.RegenerateStat();
                manaBar.value = mana.currentAmount;
            }
        }
        else
        {
            mana.Modify(-.01f);
            manaBar.value = mana.currentAmount;
        }
    }

}
