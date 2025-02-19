using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private CollisionComponent collisionComponent;
    private ShapeShift shapeShiftComponent;
    public Stats mana;


    private void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        collisionComponent = GetComponent<CollisionComponent>();
        shapeShiftComponent = GetComponent<ShapeShift>();
        mana = new Stats("Mana", 100f);
        Debug.Log(mana.statName + ": " + mana.maxAmount);    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            movementComponent.Move(Input.GetAxisRaw("Horizontal"));
        }

        if (collisionComponent.onGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                movementComponent.Jump();
            }
        }
        if (mana.currentAmount < mana.maxAmount)
        {
            mana.RegenerateStat();
        }

/*        if (1 == 1)
        {
            mana.Modify(-1);
            print(mana.currentAmount);
        }*/
    }


}
