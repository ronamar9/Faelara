using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private CollisionComponent collisionComponent;
    public Stats mana;
    private WeaponType currentWeaponType = WeaponType.Melee;


    private void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        collisionComponent = GetComponent<CollisionComponent>();
        mana = new Stats("Mana", 100f);
        Debug.Log(mana.statName + ": " + mana.maxAmount);
        Debug.Log((int)currentWeaponType);
    }

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
    }


}
