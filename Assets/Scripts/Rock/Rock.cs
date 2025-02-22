using UnityEngine;

public class Rock : MonoBehaviour
{
    private int life = 3;

    public void GetDamage()
    {
        life--;
        print(life);
        if (life <= 0)
        {
            Crush();
        }
    }

    private void Crush()
    {
        Destroy(this.gameObject);
    }
}
