using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MovementComponent movementComponent;
    private CollisionComponent collisionComponent;
    public Stats[] stats = new Stats[2];
    private WeaponType currentWeaponType = WeaponType.Melee;


    private void Start()
    {
        movementComponent = GetComponent<MovementComponent>();
        collisionComponent = GetComponent<CollisionComponent>();
        stats[0] = new Stats("Health", 50f);
        stats[1] = new Stats("Mana", 50f);
        Debug.Log(stats[0].statName + ": " + stats[0].MaxAmount);
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
    }


}
