using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private CollisionComponent collisionComponent;
    private ShapeShift shapeShiftComponent;
    public Stats mana;
    public Slider manaBar;
    private WeaponType WeaponType;
    private void Start()
    {
        movementComponent = GetComponentInChildren<MovementComponent>();
        shapeShiftComponent = GetComponent<ShapeShift>();
        collisionComponent = GetComponentInChildren<CollisionComponent>();

        mana = new Stats("Mana", 100f, 50f);
        WeaponType = WeaponType.Unarmed;
        manaBar.maxValue = mana.maxAmount;
        manaBar.value = mana.currentAmount;
    }

    private void Update()
    {
        if (mana.currentAmount < mana.maxAmount)
        {
            mana.RegenerateStat();
            manaBar.value = mana.currentAmount;
        }
    }

    public void UpdateCollisionComponent(CollisionComponent newCollision)
    {
        collisionComponent = newCollision;
    }
}
